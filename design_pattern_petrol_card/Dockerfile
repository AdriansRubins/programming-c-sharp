# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /design_pattern_petrol_card

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use the runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /design_pattern_petrol_card

COPY --from=build /design_pattern_petrol_card/out .
ENTRYPOINT ["dotnet", "design_pattern_petrol_card.dll"]
