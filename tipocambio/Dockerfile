FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TipoCambioAPI/TipoCambioAPI.csproj", "TipoCambioAPI/"]
RUN dotnet restore "TipoCambioAPI/TipoCambioAPI.csproj"
COPY . .
WORKDIR "/src/TipoCambioAPI"
RUN dotnet build "TipoCambioAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TipoCambioAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN pwd
RUN ls -lR .
ENTRYPOINT ["dotnet", "TipoCambioAPI.dll"]