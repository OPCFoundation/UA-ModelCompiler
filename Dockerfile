FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore "Opc.Ua.ModelCompiler.Tool\Opc.Ua.ModelCompiler.Tool.csproj"

# copy and publish app and libraries
COPY . .
RUN dotnet publish "Opc.Ua.ModelCompiler.Tool\Opc.Ua.ModelCompiler.Tool.csproj" -f net9.0 -c Docker -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["/app/Opc.Ua.ModelCompiler"]
