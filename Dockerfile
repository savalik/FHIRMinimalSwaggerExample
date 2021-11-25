FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FhirSwaggerExample.csproj", "./"]
RUN dotnet restore "FhirSwaggerExample.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "FhirSwaggerExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FhirSwaggerExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FhirSwaggerExample.dll"]
