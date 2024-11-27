FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./*.sln ./
COPY ./SistemaReservas.API/*.csproj ./SistemaReservas.API/
COPY ./SistemaReservas.Application/*.csproj ./SistemaReservas.Application/
COPY ./SistemaReservas.Infrastructure/*.csproj ./SistemaReservas.Infrastructure/

RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto 80 para el contenedor
EXPOSE 80
EXPOSE 443

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "SistemaReservas.API.dll"]
