FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VeconinterTechnicalTest.Web/VeconinterTechnicalTest.Web.csproj", "VeconinterTechnicalTest.Web/"]
COPY ["VeconinterTechnicalTest.Application/VeconinterTechnicalTest.Application.csproj", "VeconinterTechnicalTest.Application/"]
COPY ["VeconinterTechnicalTest.Domain/VeconinterTechnicalTest.Domain.csproj", "VeconinterTechnicalTest.Domain/"]
COPY ["VeconinterTechnicalTest.Infrastructure/VeconinterTechnicalTest.Infrastructure.csproj", "VeconinterTechnicalTest.Infrastructure/"]

RUN dotnet restore "VeconinterTechnicalTest.Web/VeconinterTechnicalTest.Web.csproj"
COPY . .
WORKDIR "/src/VeconinterTechnicalTest.Web"
RUN dotnet build "./VeconinterTechnicalTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VeconinterTechnicalTest.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VeconinterTechnicalTest.Web.dll"]
