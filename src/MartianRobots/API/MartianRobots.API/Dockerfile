#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API/MartianRobots.API/MartianRobots.API.csproj", "API/MartianRobots.API/"]
RUN dotnet restore "API/MartianRobots.API/MartianRobots.API.csproj"
COPY . .
WORKDIR "/src/API/MartianRobots.API"
RUN dotnet build "MartianRobots.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MartianRobots.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MartianRobots.API.dll"]