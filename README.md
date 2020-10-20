# 😀 core-me
🚧 __5.0-preview 分支是使用 .NET 5.0-preview、 Vue 2 与 TypeScript 的新版本，当前尚未完成__
<br>
🚧 __如需一个可以运行的实例，请访问 [2.1 分支](https://github.com/Surbowl/core-me/tree/2.1)，2.1 使用 .NET Core 2.1 与 jQuery__
<br><br>
core-me 是一个敲可爱的 mini 个人网站，拥有简洁的界面与丰富的动效，响应式布局兼容各种设备，并带有留言功能
<br>
您可以利用它开发自己的社交或求职网站
<br><br>
Core-me is a lovely personal website, you can use it to develop your own social or resume site.
<br><br>
👉 [查看 Demo](https://surbowl.online)
<br><br>
## 语言&框架
- C# 9
- HTML/CSS/JS
- [Vue](https://vuejs.org/)
- [Bulma](https://github.com/jgthms/bulma)
- [ASP.NET Core MVC](https://github.com/aspnet/AspNetCore)
<br><br>
## 依赖
- ASP.NET Core 5.0 Runtime
- [Redis](https://github.com/microsoftarchive/redis/releases)
<br><br>
## 版本&特性
- [2.1](https://github.com/Surbowl/core-me/tree/2.1) 
  - .NET Core 2.1
  - BULMA 0.8.x
  - jQuery 3.3.x
- [5.0-preview](https://github.com/Surbowl/core-me/tree/5.0-preview) 
  - .NET 5.0 Preview
  - C# nullable reference types
  - BULMA 0.9.x
  - Vue 2.6.x
  - TypeScript (target es5)
  - Webpack
<br><br>
## 部署
### 将留言通过 Smtp 转发至您的 Email
请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释补全您的 Email Smtp 配置。
<br><br>
### 留言板防骚扰
此 Branch 将访问者的 IP 与留言时间存储在 Redis 中，实现防骚扰功能。请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释编辑您的 Redis 配置。
<br><br>
## License
Code released under [the MIT license](https://github.com/Surbowl/core-me/blob/master/LICENSE).
