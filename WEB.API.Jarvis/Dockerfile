#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WEB.API.Jarvis/WEB.API.Jarvis.csproj", "WEB.API.Jarvis/"]
RUN dotnet restore "WEB.API.Jarvis/WEB.API.Jarvis.csproj"
COPY . .
WORKDIR "/src/WEB.API.Jarvis"
RUN dotnet build "WEB.API.Jarvis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WEB.API.Jarvis.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WEB.API.Jarvis.dll"]