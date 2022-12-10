#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ordering.Api/Ordering.Api.csproj", "Ordering.Api/"]
COPY ["Ordering.Application/Ordering.Application.csproj", "Ordering.Application/"]
COPY ["Ordering.Domain/Ordering.Domain.csproj", "Ordering.Domain/"]
COPY ["Ordering.Infraestructure/Ordering.Infraestructure.csproj", "Ordering.Infraestructure/"]
RUN dotnet restore "Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]