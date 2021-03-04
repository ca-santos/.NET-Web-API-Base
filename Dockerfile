FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY ./MovieMaker.sln ./MovieMaker.sln

COPY */*.csproj ./

RUN for project in $(ls *.csproj); do mkdir -p ${project%.*}/ && mv $project ${project%.*}/; done
RUN dotnet restore

COPY . .

WORKDIR "/src/MovieMaker.Web.Api"

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "MovieMaker.Web.Api.dll"]