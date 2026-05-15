FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY vbnet-stakeholder.vbproj ./
RUN dotnet restore vbnet-stakeholder.vbproj
COPY src ./src
COPY tests ./tests
RUN dotnet build vbnet-stakeholder.vbproj --configuration Release --no-restore
RUN DOTNET_BIN="dotnet run --configuration Release --no-build --project vbnet-stakeholder.vbproj --" bash tests/test_cli.sh
RUN dotnet publish vbnet-stakeholder.vbproj --configuration Release --no-build --output /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "vbnet-stakeholder.dll"]
