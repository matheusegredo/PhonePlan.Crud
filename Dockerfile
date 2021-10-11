FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ENV ASPNETCORE_URLS http://*:44319
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 44319

WORKDIR /src
COPY ["PhonePlan.Crud/PhonePlan.Crud.Api.csproj", "PhonePlan.Crud/"]
COPY ["PhonePlan.Application/PhonePlan.Application.csproj", "PhonePlan.Application/"]
COPY ["PhonePlan.Domain/PhonePlan.Domain.csproj", "PhonePlan.Domain/"]
COPY ["PhonePlan.CrossCutting/PhonePlan.CrossCutting.csproj", "PhonePlan.CrossCutting/"]
RUN dotnet restore "PhonePlan.Crud/PhonePlan.Crud.Api.csproj"
COPY . .

WORKDIR "/src/PhonePlan.Crud"

FROM build AS publish
RUN dotnet publish "PhonePlan.Crud.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhonePlan.Crud.Api.dll"]