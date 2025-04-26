# --- Etapa 1: Construcción del proyecto ---
# --- Etapa 1: Build ---
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /app
    
    # Copiar archivos
    COPY *.sln .
    COPY *.csproj .
    COPY . .
    
    # Restaurar dependencias
    RUN dotnet restore
    
    # Publicar la app
    RUN dotnet publish -c Release -o /out
    
    # --- Etapa 2: Imagen final ---
    FROM mcr.microsoft.com/dotnet/aspnet:8.0
    WORKDIR /app
    COPY --from=build /out .
    
    # Exponer el puerto (Render asigna dinámicamente)
    ENV ASPNETCORE_URLS=http://+:10000
    EXPOSE 10000
    
    ENTRYPOINT ["dotnet", "equiposPeruanos.dll"]
    