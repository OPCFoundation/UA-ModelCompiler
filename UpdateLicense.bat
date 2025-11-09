@ECHO off
SETLOCAL

set ROOT=%~dp0
set MODELCOMPILER=%ROOT%build\bin\Release\net9.0\Opc.Ua.ModelCompiler.exe
set OUTPUT=%1

"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.xml -license MITXML -silent
"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.xsd -license MITXML -silent
"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.bsd -license MITXML -silent
"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.cs -license MIT -silent
"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.h -license MIT -silent
"%MODELCOMPILER%" update-headers -input %OUTPUT% -pattern *.c -license MIT -silent

:theEnd
ENDLOCAL