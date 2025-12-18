FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore "ModelCompiler.sln"

# copy and publish app and libraries
COPY . .
RUN dotnet publish "ModelCompiler.sln" -f net9.0 -c Docker -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "/app/Opc.Ua.ModelCompiler.dll"]
