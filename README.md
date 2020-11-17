# Cocoa-web
My personal website, based on [aspnetcore-vue-typescript-template](https://github.com/danijelh/aspnetcore-vue-typescript-template).

👉 [Demo](https://surbowl.online)

<p style="text-align:center">
    <a href="./LICENSE">
      <img src="https://img.shields.io/badge/license-MIT-blue.svg?style=flat" />
    </a>
    <a href="https://github.com/Surbowl/cocoa-web/pulls">
        <img src="https://img.shields.io/badge/PRs-welcome-brightgreen.svg" alt="prs welcome">
    </a>
</p>

## Features
- .NET 5.0
- Vue 2.6
- TypeScript
- Bulma
- Scss
- Webpack
- Docker

## Build & Run locally
#### Prerequisites
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet-core)
- [Node.js](https://nodejs.org)
#### Step 1: Install front end packages
    npm install
#### Step 2: Build & run app 🚀
    dotnet run

## Or build docker image
    docker build -t cocoa-web:5.0 .
See [Dockerfile](https://github.com/Surbowl/cocoa-web/blob/5.0.0/src/Dockerfile) for more info.

## Development, publishing and available commands
- `npm run dev` - Builds front end in development mode and watches for any changes made to the files.
- `npm run build:dev` - Builds front end in development mode.
- `npm run build:prod` - Builds front end in production mode.

## Licence
[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/LICENSE)

Copyright (c) 2020-Present [碗碗](https://github.com/Surbowl)
