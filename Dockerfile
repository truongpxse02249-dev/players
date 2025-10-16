FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY players/*.csproj ./players/
RUN dotnet restore players/players.csproj

COPY players/. ./players/
WORKDIR /src/players
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "players.dll"]
