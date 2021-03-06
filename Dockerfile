FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:8080

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
ARG Configuration=Release

WORKDIR /src
COPY *.sln ./

COPY */*.csproj ./
RUN for project in $(ls *.csproj); do mkdir -p ${project%.*}/ && mv $project ${project%.*}/; done

RUN dotnet restore

COPY . .
WORKDIR /src/MovieMaker.Web.Api
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovieMaker.Web.Api.dll"]