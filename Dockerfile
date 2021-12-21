FROM mcr.microsoft.com/dotnet/runtime:5.0
# execute dockerbuild to publish the project

COPY ./publish /app
WORKDIR /app

ENTRYPOINT ["dotnet", "Opc.Ua.ModelCompiler.dll"]
