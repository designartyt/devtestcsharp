FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CrudTest.API/CrudTest.API.csproj", "CrudTest.API/"]
RUN dotnet restore "CrudTest.API/CrudTest.API.csproj"
COPY . .
WORKDIR "/src/CrudTest.API"
RUN dotnet build "CrudTest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudTest.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudTest.API.dll"]
