SETLOCAL

set MODELCOMPILER=.\Bin\Debug\Opc.Ua.ModelCompiler.exe

%MODELCOMPILER% -d2 ".\Input\OpcUaDiModel.xml" -cg ".\Input\OpcUaDiModel.csv" -o2 ".\Out"

ENDLOCAL

cmd /k