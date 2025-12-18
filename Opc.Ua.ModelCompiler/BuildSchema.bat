@echo off
setlocal

set XSD=xsd

where %XSD% >nul 2>&1
if not %ERRORLEVEL%==0 (
    color 
    echo %XSD% is NOT in the PATH.
    exit 1
)

cd %~dp0

echo Processing UA Model Design Schema
%XSD% /classes /n:ModelCompiler "UA Model Design.xsd"

powershell -NoProfile -Command ^
  "$content = Get-Content -Raw -Encoding UTF8 'UA Model Design.cs';" ^
  "$utf8NoBom = New-Object System.Text.UTF8Encoding $false;" ^
  "[System.IO.File]::WriteAllText('temp1.txt', $content, $utf8NoBom)"

echo #pragma warning disable 1591 > temp2.txt
type temp1.txt >> temp2.txt
type temp2.txt > "UA Model Design.cs"

cd .\StackGenerator\Validators

echo Processing UA Type Dictionary Schema
%XSD%  /classes /n:CodeGenerator "UA Type Dictionary.xsd"

powershell -NoProfile -Command ^
  "$content = Get-Content -Raw -Encoding UTF8 'UA Type Dictionary.cs';" ^
  "$utf8NoBom = New-Object System.Text.UTF8Encoding $false;" ^
  "[System.IO.File]::WriteAllText('temp1.txt', $content, $utf8NoBom)"
  
echo #pragma warning disable 1591 > temp2.txt
type temp1.txt >> temp2.txt
type temp2.txt > "UA Type Dictionary.cs"

del /Q temp1.txt
del /Q temp2.txt
