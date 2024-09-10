FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
WORKDIR /src
COPY ["src/TestAuth.Api/TestAuth.Api.csproj", "src/TestAuth.Api/"]
COPY ["src/TestAuth.Core/TestAuth.Core.csproj", "src/TestAuth.Core/"]
COPY ["src/TestAuth.Infrastructure/TestAuth.Infrastructure.csproj", "src/TestAuth.Infrastructure/"]
RUN dotnet restore "src/TestAuth.Api/TestAuth.Api.csproj"
COPY . .
WORKDIR "/src/src/TestAuth.Api"
RUN dotnet build "TestAuth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TestAuth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAuth.Api.dll"]
