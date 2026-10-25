# slika, ki jo uporabimo za osnovo/strežnik

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

# delovni direktorij v sliki

WORKDIR /app

 

# vrata, ki jih želimo odpreti

EXPOSE 8080

EXPOSE 443

 

# slika, ki jo uporabimo za izgradnjo

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# kopiranje datotek v delovni direktorij

COPY ["Nepremicnine_RGIS/Nepremicnine_RGIS.csproj", "Nepremicnine_RGIS/"]

# zagon ukaza za obnovo vseh odvisnosti

RUN dotnet restore "Nepremicnine_RGIS/Nepremicnine_RGIS.csproj"

COPY . .

WORKDIR "/src/Nepremicnine_RGIS"

# zagon ukaza za izgradnjo projekta

RUN dotnet build "Nepremicnine_RGIS.csproj" -c Release -o /app/build

 

FROM build AS publish

RUN dotnet publish "Nepremicnine_RGIS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# zagon ukaza za objavo projekta

 

FROM base AS final

WORKDIR /app

# kopiranje datotek iz začasne slike v končno

COPY --from=publish /app/publish .

# zagon ukaza za zagon aplikacije

ENTRYPOINT ["dotnet", "Nepremicnine_RGIS.dll"]