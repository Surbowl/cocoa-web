# 😆 core-me
core-me 是一个敲可爱的 mini 个人网站，拥有简洁的界面与丰富的动效，响应式布局兼容各种设备，并带有留言功能
<br>
您可以利用它开发自己的社交或求职网站
<br><br>
Core-me is a lovely personal website, you can use it to develop your own social or resume site.
<br><br>
👉 [查看 Demo](https://surbowl.online)
<br><br>
## 语言&框架
- C#
- HTML/CSS/JS
- [Bulma](https://github.com/jgthms/bulma)
- [ASP.NET Core MVC](https://github.com/aspnet/AspNetCore)
<br><br>
## 依赖
- ASP.NET Core 2.1 Runtime
- [Redis](https://github.com/microsoftarchive/redis/releases)
<br><br>
## 分支&版本
- [2.1](https://github.com/Surbowl/core-me/tree/2.1) 
  - .NET Core 2.1
  - C# 7.3
  - BULMA 0.8.x
  - jQuery 3.3.x
- [5.0-preview](https://github.com/Surbowl/core-me/tree/5.0-preview) 
  - .NET 5.0 Preview
  - C# 9.0
  - BULMA 0.9.x
  - Vue 2.6.x
<br><br>
## 部署
### 将留言通过 Smtp 转发至您的 Email
请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释补全您的 Email Smtp 配置。
<br><br>
### 留言板防骚扰
此 Branch 将访问者的 IP 与留言时间存储在 Redis 中，实现防骚扰功能。请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释编辑您的 Redis 配置。
<br><br>
### 使用 Kestrel 部署项目
您可以使用 Kestrel 直接部署项目，Kestrel 是一个跨平台的适用于 ASP.NET Core 的 Web 服务器，已经包含在项目模板中。下面是在 Windows 平台部署项目的入门教程：
- 确保您的计算机支持 ASP.NET Core 2.1 或更高版本
- 启动 Redis
- 将 core-me 项目发布到文件夹
- 在 cmd 命令行访问发布项目的文件夹
- 输入 dotnet 指令启动 core-me.dll 文件
``` bash
# 请将此路径替换成您自己的
cd C:\CoreMe\publish

dotnet CoreMe.dll
```
现在，core-me成功地运行在您的计算机上了，您可访问 [http://localhost:80](http://localhost:80) 查看它！
<br>
如需启用 Https，可访问项目根目录下的 appsettings.json 与 Program.cs 文件，文件中已为您编写好了相应代码，只需根据注释进行修改即可。
<br><br>
您可访问微软提供的[文档](https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/?view=aspnetcore-3.0)查看更多部署方式。
<br><br>
## License
Code released under [the MIT license](https://github.com/Surbowl/core-me/blob/master/LICENSE).
