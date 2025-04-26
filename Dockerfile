# --- Etapa 1: Construcción del proyecto ---
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /app
    
    COPY *.sln .
    COPY equiposPeruanos/*.csproj ./equiposPeruanos/
    RUN dotnet restore
    
    COPY . .
    WORKDIR /app/equiposPeruanos
    RUN dotnet publish -c Release -o /out
    
    # --- Etapa 2: Imagen final ---
    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
    WORKDIR /app
    COPY --from=build /out .
    
    EXPOSE 80
    
    ENTRYPOINT ["dotnet", "equiposPeruanos.dll"]
    