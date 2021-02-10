FROM mono:latest
ADD . /tmp/app-build
WORKDIR /tmp/app-build
ADD https://dist.nuget.org/win-x86-commandline/latest/nuget.exe /tmp/app-build/nuget.exe
RUN mono nuget.exe install -OutputDirectory packages ModelCompiler/packages.config
RUN msbuild "ModelCompiler Solution.sln" /t:Restore /t:Build /p:Configuration=Release

# Only keep the compiled files
RUN mv /tmp/app-build/Bin/Release /app
# Copy the necessary design files used by the model compiler
RUN mv /tmp/app-build/ModelCompiler/Design* /app
RUN mv /tmp/app-build/PublishModel.* /app

WORKDIR /app
RUN rm -rf /tmp/app-build

ENTRYPOINT ["mono", "/app/Opc.Ua.ModelCompiler.exe"]
