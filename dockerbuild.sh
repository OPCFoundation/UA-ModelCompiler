#!/bin/bash
echo build a docker container of the ModelCompiler
dotnet build --configuration Release --framework net5.0 "./Opc.Ua.ModelCompiler/Opc.Ua.ModelCompiler.csproj"
dotnet publish --configuration Release --framework net5.0 "./Opc.Ua.ModelCompiler/Opc.Ua.ModelCompiler.csproj" -o ./publish
sudo docker build -t modelcompiler .
