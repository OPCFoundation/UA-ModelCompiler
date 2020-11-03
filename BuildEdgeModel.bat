SETLOCAL

set MODELCOMPILER=.\Bin\Debug\Opc.Ua.ModelCompiler.exe

%MODELCOMPILER% -d2 ".\Input\EdgeModel.xml" -cg ".\Input\EdgeModel.csv" -o2 ".\Out"

ENDLOCAL

cmd /k