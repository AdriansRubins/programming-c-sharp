FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["aufgaben/aufgaben.sln", "aufgaben/"]
RUN dotnet restore "aufgaben/aufgaben.sln"
COPY . .
WORKDIR "/src/data_structures"
RUN dotnet build "aufgaben.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "data_structures.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "data_structures.dll"]
