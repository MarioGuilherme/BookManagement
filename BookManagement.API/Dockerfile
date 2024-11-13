# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Instala as culturas e configura a cultura brasileira
USER root
ENV TZ=America/Sao_Paulo
RUN apk add --no-cache icu-libs icu-data-full tzdata
ENV LANG=pt_BR.UTF-8
ENV LANGUAGE=pt_BR:pt
ENV LC_ALL=pt_BR.UTF-8
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookManagement.API/BookManagement.API.csproj", "BookManagement.API/"]
COPY ["BookManagement.Application/BookManagement.Application.csproj", "BookManagement.Application/"]
COPY ["BookManagement.Core/BookManagement.Core.csproj", "BookManagement.Core/"]
COPY ["BookManagement.Infrastructure/BookManagement.Infrastructure.csproj", "BookManagement.Infrastructure/"]
RUN dotnet restore "./BookManagement.API/BookManagement.API.csproj"
COPY . .
WORKDIR "/src/BookManagement.API"
RUN dotnet build "./BookManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookManagement.API.dll"]