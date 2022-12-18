#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/IFRSDemo.Migrator/IFRSDemo.Migrator.csproj", "src/IFRSDemo.Migrator/"]
COPY ["src/IFRSDemo.EntityFrameworkCore/IFRSDemo.EntityFrameworkCore.csproj", "src/IFRSDemo.EntityFrameworkCore/"]
COPY ["src/IFRSDemo.Core/IFRSDemo.Core.csproj", "src/IFRSDemo.Core/"]
COPY ["src/IFRSDemo.Core.Shared/IFRSDemo.Core.Shared.csproj", "src/IFRSDemo.Core.Shared/"]
RUN dotnet restore "src/IFRSDemo.Migrator/IFRSDemo.Migrator.csproj"
COPY . .
WORKDIR "/src/src/IFRSDemo.Migrator"
RUN dotnet build "IFRSDemo.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFRSDemo.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFRSDemo.Migrator.dll"]
