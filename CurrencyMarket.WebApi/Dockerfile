#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CurrencyMarket.WebApi/CurrencyMarket.WebApi.csproj", "CurrencyMarket.WebApi/"]
COPY ["CurrencyMarket.Infraestructure/CurrencyMarket.Infraestructure.csproj", "CurrencyMarket.Infraestructure/"]
COPY ["CurrencyMarket.Entities/CurrencyMarket.Entities.csproj", "CurrencyMarket.Entities/"]
COPY ["CurrencyMarket.Core/CurrencyMarket.Core.csproj", "CurrencyMarket.Core/"]
COPY ["CurrencyMarket.Common/CurrencyMarket.Common.csproj", "CurrencyMarket.Common/"]
RUN dotnet restore "CurrencyMarket.WebApi/CurrencyMarket.WebApi.csproj"
COPY . .
WORKDIR "/src/CurrencyMarket.WebApi"
RUN dotnet build "CurrencyMarket.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurrencyMarket.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurrencyMarket.WebApi.dll"]