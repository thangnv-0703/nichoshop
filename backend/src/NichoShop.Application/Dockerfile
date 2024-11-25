#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NichoShop.Application/NichoShop.Application.csproj", "NichoShop.Application/"]
COPY ["NichoShop.Domain/NichoShop.Domain.csproj", "NichoShop.Domain/"]
COPY ["NichoShop.Infrastructure/NichoShop.Infrastructure.csproj", "NichoShop.Infrastructure/"]
RUN dotnet restore "./NichoShop.Application/NichoShop.Application.csproj"
COPY . .
WORKDIR "/src/NichoShop.Application"
RUN dotnet build "./NichoShop.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NichoShop.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NichoShop.Application.dll"]