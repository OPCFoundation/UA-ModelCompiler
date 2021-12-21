#!/bin/bash
echo build a docker container of the ModelCompiler
dotnet build --configuration Release --framework net5.0 "ModelCompiler Solution.sln"
dotnet publish --configuration Release --framework net5.0 "ModelCompiler Solution.sln" -o ./publish
sudo docker build -t modelcompiler .
