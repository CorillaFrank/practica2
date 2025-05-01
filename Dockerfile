FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiamos el archivo del proyecto
COPY practica2.csproj ./
RUN dotnet restore

# Copiamos el resto del código (controladores, vistas, etc.)
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Indicamos el nombre del ejecutable final
ENV APP_NET_CORE practica2.dll

# Comando que ejecuta la app en Render
CMD ASPNETCORE_URLS=http://:$PORT dotnet $APP_NET_CORE

