#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM node:lts-buster-slim AS build-vue
WORKDIR /src
COPY ["package*.json", "tsconfig.json", "*.js", "*.ts", "./"]
COPY ./VueApp ./VueApp
RUN npm install \
    && npm run build:prod

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build-dotnet
WORKDIR /src
COPY ["Cocoa.Web.csproj", ""]
RUN dotnet restore "./Cocoa.Web.csproj"
COPY . .
COPY --from=build-vue /src/wwwroot/dist ./wwwroot/dist
WORKDIR "/src/."
RUN dotnet build "Cocoa.Web.csproj" -c Docker -o /app/build

FROM build-dotnet AS publish-dotnet
RUN dotnet publish "Cocoa.Web.csproj" -c Docker -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish-dotnet /app/publish .
ENV ASPNETCORE_ENVIRONMENT="ProductionWithOutSsl"
ENTRYPOINT ["dotnet", "Cocoa.Web.dll"]