@echo off
setlocal

cd %~dp0

echo Processing UA Model Design Schema
xsd /classes /n:ModelCompiler "UA Model Design.xsd"

echo #pragma warning disable 1591 > temp.txt
type "UA Model Design.cs" >> temp.txt
type temp.txt > "UA Model Design.cs"

cd .\StackGenerator\Validators

echo Processing UA Type Dictionary Schema
xsd /classes /n:CodeGenerator "UA Type Dictionary.xsd"

echo #pragma warning disable 1591 > temp.txt
type "UA Type Dictionary.cs" >> temp.txt
type temp.txt > "UA Type Dictionary.cs"
