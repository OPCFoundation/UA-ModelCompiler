<#
.SYNOPSIS
    Builds, packs, and optionally signs the OPC UA Model Compiler .NET tool.

.DESCRIPTION
    Run signing-key.ps1 first to set the signing environment variables, then run this script.
    Version is determined automatically by Nerdbank.GitVersioning from version.json + git height.

        . .\signing-key.ps1
        .\build.ps1

    Signing is enabled when ALL of the following environment variables are set:
        SigningCertName, SigningClientId, SigningClientSecret, SigningTenantId, SigningVaultURL
    Optional: SigningURL (RFC 3161 timestamp URL; defaults to http://timestamp.digicert.com)

.PARAMETER Configuration
    Build configuration. Defaults to Release.

.PARAMETER ReleaseType
    Preview (default) - produces a prerelease package (e.g. 2.8.123-preview-<sha>).
    Release           - produces a stable package (e.g. 2.8.123) by forcing
                        Nerdbank.GitVersioning PublicRelease=true, which strips
                        the -preview tag declared in version.json.

.PARAMETER OutputDir
    Directory for the .nupkg output. Defaults to ./packages.

.PARAMETER SkipTests
    Skip running tests. Defaults to on (the tool solution does not include test projects).

.PARAMETER SkipSign
    Skip signing even when signing environment variables are set.
#>
param(
    [string]$Configuration = "Release",
    [ValidateSet('Preview','Release')]
    [string]$ReleaseType = "Preview",
    [string]$OutputDir = "$PSScriptRoot/packages",
    [switch]$SkipTests = $true,
    [switch]$SkipSign
)

$ErrorActionPreference = 'Stop'
$Solution = "$PSScriptRoot/Opc.Ua.ModelCompiler.Tool.slnx"
$ToolProject = "$PSScriptRoot/Opc.Ua.ModelCompiler.Tool/Opc.Ua.ModelCompiler.Tool.csproj"

# Version handling is fully controlled by Nerdbank.GitVersioning (NBGV) — it
# reads version.json from the committed git tree and ignores MSBuild attempts
# to override PackageVersion. The $ReleaseType switch is applied separately
# (see the post-build "strip prerelease" step below for Release mode).
$PublicRelease = if ($ReleaseType -eq 'Release') { 'true' } else { 'false' }
$VersionArgs   = @("-p:PublicRelease=$PublicRelease")
Write-Host "ReleaseType=$ReleaseType (PublicRelease=$PublicRelease)" -ForegroundColor Cyan


# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------
function Write-Step([string]$msg) { Write-Host "`n>>> $msg" -ForegroundColor Cyan }

# Post-processes a .nupkg or .snupkg to drop the prerelease tag from its embedded
# version, renaming the file to match (e.g. Foo.1.2.3-preview.nupkg -> Foo.1.2.3.nupkg).
# Used by Release-mode builds because NBGV will not let us override PackageVersion
# from MSBuild and refuses to read version.json from the working tree.
function Remove-NupkgPrereleaseTag {
    param([Parameter(Mandatory=$true)][string]$NupkgPath)
    Add-Type -AssemblyName System.IO.Compression
    Add-Type -AssemblyName System.IO.Compression.FileSystem

    $dir = Split-Path $NupkgPath -Parent
    $ext = [System.IO.Path]::GetExtension($NupkgPath)

    # Rewrite ONLY the .nuspec <version> in place, leaving every other entry
    # byte-for-byte. We must NOT extract + re-zip the package: under Windows
    # PowerShell 5.1 / .NET Framework, [ZipFile]::CreateFromDirectory writes
    # entry names with '\' separators, which violates the OPC/ZIP layout NuGet
    # expects and makes `dotnet tool install` fail to find
    # tools/<tfm>/any/DotnetToolSettings.xml. Editing the entry in Update mode
    # preserves the SDK's original '/'-separated names.
    $oldVersion = $null; $newVersion = $null; $packageId = $null
    $zip = [System.IO.Compression.ZipFile]::Open($NupkgPath, [System.IO.Compression.ZipArchiveMode]::Update)
    try {
        # The package-level nuspec sits at the archive root (no folder separator).
        $nuspecEntry = $zip.Entries |
            Where-Object { $_.FullName -like '*.nuspec' -and $_.FullName -notmatch '[\\/]' } |
            Select-Object -First 1
        if (-not $nuspecEntry) { throw "No .nuspec found inside $NupkgPath" }

        $reader  = New-Object System.IO.StreamReader($nuspecEntry.Open())
        $content = $reader.ReadToEnd()
        $reader.Dispose()

        $packageId  = ([regex]'<id>([^<]+)</id>').Match($content).Groups[1].Value
        $oldVersion = ([regex]'<version>([^<]+)</version>').Match($content).Groups[1].Value
        $dashIdx    = $oldVersion.IndexOf('-')
        if ($dashIdx -lt 0) { return $NupkgPath }   # already a stable version
        $newVersion = $oldVersion.Substring(0, $dashIdx)

        # Replace only the first <version> element (the package version);
        # dependency entries carry their version in a version="..." attribute.
        $patched = ([regex]'(<version>)[^<]+(</version>)').Replace($content, ('${1}' + $newVersion + '${2}'), 1)

        # Truncate and rewrite the existing entry in place (UTF-8 with BOM, as NuGet emits).
        $stream = $nuspecEntry.Open()
        $stream.SetLength(0)
        $writer = New-Object System.IO.StreamWriter($stream, (New-Object System.Text.UTF8Encoding($true)))
        $writer.Write($patched)
        $writer.Dispose()
    } finally {
        $zip.Dispose()
    }

    $newFileName = "$packageId.$newVersion$ext"
    $newPath     = Join-Path $dir $newFileName
    if ($newPath -ne $NupkgPath) {
        if (Test-Path $newPath) { Remove-Item $newPath -Force }
        Move-Item -LiteralPath $NupkgPath -Destination $newPath -Force
    }
    Write-Host "  $([System.IO.Path]::GetFileName($NupkgPath)) -> $newFileName ($oldVersion -> $newVersion)" -ForegroundColor DarkGray
    return $newPath
}

function Invoke-DotNet {
    $cmd = "dotnet $args"
    Write-Host $cmd -ForegroundColor DarkGray
    & dotnet @args
    if ($LASTEXITCODE -ne 0) { throw "dotnet command failed with exit code $LASTEXITCODE" }
}

# Hard-deletes a directory and halts if anything is locked. We must clean obj/
# unconditionally — the Opc.Ua.ModelCompiler[.Tool] folders each hold both the
# multi-TFM csproj and a single-TFM .Debug.csproj, and they share obj/. If a
# stale Debug restore wins project.assets.json (missing net10.0), the build
# fails with NETSDK1005. Silently skipping a locked obj/ would leave that
# stale state intact, so refuse to proceed instead.
function Remove-DirOrFail {
    param([Parameter(Mandatory=$true)][string]$Path)
    if (-not (Test-Path -LiteralPath $Path)) { return }
    try {
        Remove-Item -LiteralPath $Path -Recurse -Force -ErrorAction Stop
    } catch {
        throw @"
Failed to delete '$Path': $($_.Exception.Message)

A file in this directory is locked. Close anything that may be holding it open
(Visual Studio / VS Code / Rider with the solution open, a running dotnet.exe,
OmniSharp, or a previous Opc.Ua.ModelCompiler.exe), then re-run build.ps1.
"@
    }
}

# ---------------------------------------------------------------------------
# Detect signing configuration
# ---------------------------------------------------------------------------
$CanSign = (-not $SkipSign) `
    -and $env:SigningCertName `
    -and $env:SigningClientId `
    -and $env:SigningClientSecret `
    -and $env:SigningTenantId `
    -and $env:SigningVaultURL

if ($CanSign) {
    Write-Host "Signing credentials detected - packages will be signed." -ForegroundColor Green
} else {
    Write-Host "No signing credentials - packages will NOT be signed." -ForegroundColor Yellow
}

# ---------------------------------------------------------------------------
# Clean
# ---------------------------------------------------------------------------
Write-Step "Clean"
Remove-DirOrFail "$PSScriptRoot/build"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler/obj"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler/bin"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler/build"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler.Tool/obj"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler.Tool/bin"
Remove-DirOrFail "$PSScriptRoot/Opc.Ua.ModelCompiler.Tool/build"
# Drop previously built nupkgs for this tool so the output directory only has the fresh ones.
if (Test-Path $OutputDir) {
    Get-ChildItem $OutputDir -Filter 'OPCFoundation.Opc.Ua.ModelCompiler.Tool.*.nupkg'  | Remove-Item -Force
    Get-ChildItem $OutputDir -Filter 'OPCFoundation.Opc.Ua.ModelCompiler.Tool.*.snupkg' | Remove-Item -Force
}

# ---------------------------------------------------------------------------
# Restore
# ---------------------------------------------------------------------------
Write-Step "Restore"
Invoke-DotNet restore $Solution

# ---------------------------------------------------------------------------
# Build (the Tool project has GeneratePackageOnBuild=true, so this also packs)
# ---------------------------------------------------------------------------
Write-Step "Build ($Configuration)"
Invoke-DotNet build $Solution -c $Configuration --no-restore -p:NoWarn=NU5128 @VersionArgs

# ---------------------------------------------------------------------------
# Test (skipped by default; the tool solution has no test projects)
# ---------------------------------------------------------------------------
if (-not $SkipTests) {
    Write-Step "Test"
    Invoke-DotNet test $Solution -c $Configuration --no-build --verbosity normal
}

# ---------------------------------------------------------------------------
# Sign binaries (requires AzureSignTool) and re-pack
# ---------------------------------------------------------------------------
if ($CanSign) {
    Write-Step "Sign binaries"

    $signTool = Get-Command AzureSignTool -ErrorAction SilentlyContinue
    if (-not $signTool) {
        Write-Host "Installing AzureSignTool..." -ForegroundColor DarkGray
        dotnet tool install --global AzureSignTool
    }

    # The Tool csproj redirects OutputPath to $(SolutionDir)build\bin\$(Configuration)\,
    # which resolves to the repo root when building via the .slnx. With multi-targeting
    # the per-TFM output lands in subfolders (net8.0/, net10.0/, ...); -Recurse below
    # picks up binaries from all of them.
    $binDir = "$PSScriptRoot/build/bin/$Configuration"
    $timestampUrl = if ($env:SigningURL) { $env:SigningURL } else { "http://timestamp.digicert.com" }

    $fileList = [System.IO.Path]::GetTempFileName()
    try {
        Get-ChildItem $binDir -Include '*.dll','*.exe' -Recurse |
            Where-Object { -not $_.Name.StartsWith('System.') -and -not $_.Name.StartsWith('Microsoft.') } |
            Select-Object -ExpandProperty FullName |
            Set-Content $fileList -Encoding utf8

        AzureSignTool sign `
            --azure-key-vault-url            $env:SigningVaultURL `
            --azure-key-vault-client-id      $env:SigningClientId `
            --azure-key-vault-client-secret  $env:SigningClientSecret `
            --azure-key-vault-tenant-id      $env:SigningTenantId `
            --azure-key-vault-certificate    $env:SigningCertName `
            --timestamp-rfc3161              $timestampUrl `
            --description                    'OPC UA Model Compiler Tool' `
            -ifl $fileList
        if ($LASTEXITCODE -ne 0) { throw "Binary signing failed." }
    } finally {
        Remove-Item $fileList -ErrorAction SilentlyContinue
    }

    Write-Step "Re-pack with signed binaries"
    # Pack via the .slnx (not the .csproj) so $(SolutionDir) resolves to the repo root,
    # matching the build step's OutputPath. Packing the csproj directly sets
    # $(SolutionDir) to the project folder and breaks the file lookups.
    Invoke-DotNet pack $Solution -c $Configuration --no-build -p:NoWarn=NU5128 @VersionArgs
}

# ---------------------------------------------------------------------------
# Release mode: rewrite the .nupkg/.snupkg to drop the -preview tag and rename.
# Runs after the (optional) re-pack with signed binaries but before nupkg-level
# signing, so the signature ends up on the final, correctly-named package.
# ---------------------------------------------------------------------------
if ($ReleaseType -eq 'Release') {
    Write-Step "Strip prerelease tag from Release packages"
    Get-ChildItem "$OutputDir/OPCFoundation.Opc.Ua.ModelCompiler.Tool.*.nupkg" | ForEach-Object {
        Remove-NupkgPrereleaseTag $_.FullName | Out-Null
    }
}

# ---------------------------------------------------------------------------
# Sign NuGet packages (requires NuGetKeyVaultSignTool)
# ---------------------------------------------------------------------------
if ($CanSign) {
    Write-Step "Sign NuGet packages"

    $signTool = Get-Command NuGetKeyVaultSignTool -ErrorAction SilentlyContinue
    if (-not $signTool) {
        Write-Host "Installing NuGetKeyVaultSignTool..." -ForegroundColor DarkGray
        dotnet tool install --global NuGetKeyVaultSignTool
    }

    $timestampUrl = if ($env:SigningURL) { $env:SigningURL } else { "http://timestamp.digicert.com" }

    Get-ChildItem "$OutputDir/OPCFoundation.Opc.Ua.ModelCompiler.Tool.*.nupkg" |
        Where-Object { $_.Name -notlike '*.snupkg' } |
        ForEach-Object {
            Write-Host "  Signing $($_.Name)" -ForegroundColor DarkGray
            NuGetKeyVaultSignTool sign $_.FullName `
                -kvu $env:SigningVaultURL `
                -kvc $env:SigningCertName `
                -kvt $env:SigningTenantId `
                -kvi $env:SigningClientId `
                -kvs $env:SigningClientSecret `
                -tr  $timestampUrl `
                -td  sha256
            if ($LASTEXITCODE -ne 0) { throw "NuGet package signing failed for $($_.Name)" }
        }
}

# ---------------------------------------------------------------------------
# Summary
# ---------------------------------------------------------------------------
Write-Step "Done"
Write-Host "Packages:"
Get-ChildItem "$OutputDir/OPCFoundation.Opc.Ua.ModelCompiler.Tool.*.nupkg" |
    Where-Object { $_.Name -notlike '*.snupkg' } |
    ForEach-Object { Write-Host "  $_" }

Write-Host ""
Write-Host "Install the tool locally with:"
Write-Host "  .\install_tool.ps1" -ForegroundColor DarkGray
Write-Host "or manually:"
Write-Host "  dotnet tool install --global --add-source $OutputDir --prerelease OPCFoundation.Opc.Ua.ModelCompiler.Tool" -ForegroundColor DarkGray
