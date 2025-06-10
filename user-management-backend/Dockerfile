# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos del proyecto
#COPY . ./
#RUN dotnet restore

# Copiar todo el código y publicar
#COPY . ./
#RUN dotnet publish -c Release -o out

# Etapa 2: Ejecución
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
#WORKDIR /app
#COPY --from=build /app/out .

# Ejecutar la app
#ENTRYPOINT ["dotnet", "./app/user-management-backend.dll"]


﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["user-management-backend.csproj", "./"]
RUN dotnet restore "user-management-backend.csproj"
COPY . .
RUN dotnet build "user-management-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build
 
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "user-management-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user-management-backend.dll"]
