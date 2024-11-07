# Use the .NET base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080    # HTTP port
EXPOSE 8081    # HTTPS port

# Use the .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BookingService/BookingService.csproj", "BookingService/"]
RUN dotnet restore "./BookingService/BookingService.csproj"
COPY . . 
WORKDIR "/src/BookingService"
RUN dotnet build "./BookingService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the app to a specific directory
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BookingService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BookingService.dll", "--urls", "http://0.0.0.0:8080;https://0.0.0.0:8081"]

