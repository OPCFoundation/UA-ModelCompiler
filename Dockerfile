FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore "ModelCompiler Solution.sln"

# copy and publish app and libraries
COPY . .
RUN dotnet publish "ModelCompiler Solution.sln" -f net6.0 -c Release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "/app/Opc.Ua.ModelCompiler.dll"]
