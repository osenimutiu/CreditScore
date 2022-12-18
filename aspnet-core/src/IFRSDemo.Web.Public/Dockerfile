#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/IFRSDemo.Web.Public/IFRSDemo.Web.Public.csproj", "src/IFRSDemo.Web.Public/"]
COPY ["src/IFRSDemo.Web.Core/IFRSDemo.Web.Core.csproj", "src/IFRSDemo.Web.Core/"]
COPY ["src/IFRSDemo.Application/IFRSDemo.Application.csproj", "src/IFRSDemo.Application/"]
COPY ["src/IFRSDemo.Application.Shared/IFRSDemo.Application.Shared.csproj", "src/IFRSDemo.Application.Shared/"]
COPY ["src/IFRSDemo.Core.Shared/IFRSDemo.Core.Shared.csproj", "src/IFRSDemo.Core.Shared/"]
COPY ["src/IFRSDemo.Core/IFRSDemo.Core.csproj", "src/IFRSDemo.Core/"]
COPY ["src/IFRSDemo.EntityFrameworkCore/IFRSDemo.EntityFrameworkCore.csproj", "src/IFRSDemo.EntityFrameworkCore/"]
COPY ["src/IFRSDemo.GraphQL/IFRSDemo.GraphQL.csproj", "src/IFRSDemo.GraphQL/"]
RUN dotnet restore "src/IFRSDemo.Web.Public/IFRSDemo.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/IFRSDemo.Web.Public"
RUN dotnet build "IFRSDemo.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFRSDemo.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFRSDemo.Web.Public.dll"]
