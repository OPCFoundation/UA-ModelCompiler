REM build a docker container of the ModelCompiler
dotnet build --configuration Release --framework net5.0 "ModelCompiler Solution.sln"
dotnet publish --configuration Release --framework net5.0 "ModelCompiler Solution.sln" -o ./publish
docker build -t modelcompiler .
