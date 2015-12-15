@ECHO off
REM ****************************************************************************************************************
REM ** Nathan Pocock (nathan.pocock@opcfoundation.org) https://opcfoundation.org/
REM ** --
REM ** This script simply cleans all temporary and generated files essentially leaving the environment clean.
REM ** --
REM ****************************************************************************************************************
ECHO ON

@ECHO Clearing the Build output
RD /s /q .\bin
RD /s /q .\ModelCompiler\obj\
RD /s /q .\Core\obj\

@ECHO Clearing the generated output (ignoring the content copied to your Stack locations)
RD /s /q .\Published\

@ECHO OFF
:theEnd
ENDLOCAL