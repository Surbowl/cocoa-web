#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM node:lts-buster-slim AS npm-install
WORKDIR /src
COPY package*.json ./
RUN npm install

FROM npm-install AS build-vue
COPY ["tsconfig.json", "*.js", "*.ts", "./"]
COPY ./VueApp ./VueApp
RUN npm run build:prod

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-dotnet
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
ENV ASPNETCORE_ENVIRONMENT="ProductionWithoutSsl"
ENTRYPOINT ["dotnet", "Cocoa.Web.dll"]