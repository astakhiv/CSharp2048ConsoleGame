FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConsoleGame2048/ConsoleGame2048.csproj", "ConsoleGame2048/"]
RUN dotnet restore "ConsoleGame2048/ConsoleGame2048.csproj"
COPY . .
WORKDIR "/src/ConsoleGame2048"
RUN dotnet build "ConsoleGame2048.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleGame2048.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleGame2048.dll"]
