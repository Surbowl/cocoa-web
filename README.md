# 😃 core-me

core-me 是一个敲可爱的个人网站，拥有简洁的界面与丰富的动效，响应式布局兼容各种设备，并带有留言功能
<br><br>
您可以利用它开发自己的社交或求职网站
<br><br>
Core-me is a lovely personal website, you can use it to develop your own social or resume site.
<br><br>
👉 [Demo](https://surbowl.online)
<br><br>
## 语言&框架
- C#
- HTML
- CSS
- JS
- [Bulma](https://github.com/jgthms/bulma)
- [ASP.NET Core MVC](https://github.com/aspnet/AspNetCore)
<br><br>
## 环境
- ASP.NET Core 2.1
- Microsoft Visual Studio Community 2019 v16.3.10
<br><br>
## 部署
### 将留言通过 Smtp 转发至您的 Email
请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释补全您的 Email Smtp 配置。
<br><br>
请注意，appsettings.json 是正式部署时采用的设置，而 appsettings.Development.json 是 localhost 调试时采用的设置，通常它们的 Email Smtp 配置保持一致即可。如果您在调试时有特殊需求，则可以利用这一特性。
<br><br>
### 使用 Kestrel 部署项目
您可以使用 Kestrel 直接部署项目，Kestrel 是一个跨平台的适用于 ASP.NET Core 的 Web 服务器，已经包含在项目模板中。
<br><br>
下面是在 Windows 平台部署项目的入门教程：
<br>
- 确保您的计算机支持 ASP.NET Core 2.1 或更高版本
- 将 core-me 项目发布到文件夹
- 在 cmd 命令行访问发布项目的文件夹
- 输入 dotnet 指令启动 core-me.dll 文件
``` bash
# 请将此路径替换成您自己的
cd C:\core-me\publish

dotnet core-me.dll
```
现在，core-me成功地运行在您的计算机上了，您可访问 [http://localhost:80](http://localhost:80) 查看它！
<br><br>
如需启用 Https，可访问项目根目录下的 appsettings.json 与 Program.cs 文件，文件中已为您编写好了相应代码，只需根据注释进行修改即可。
<br><br>
您可访问微软提供的[文档](https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/?view=aspnetcore-3.0)查看更多部署方式。
