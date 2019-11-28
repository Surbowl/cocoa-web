# 😃 core-me

core-me 是一个敲可爱的个人小网站，拥有简洁的界面与丰富的动效，带有留言功能
<br><br>
您可以利用它开发自己的社交或求职网站
<br><br>
👉查看[示例网站](https://surbowl.online)
<br><br>
## 语言&框架
- C#
- HTML
- CSS
- JS
- [Bulma](https://github.com/jgthms/bulma)
- [ASP.NET Core 2.1 MVC](https://github.com/aspnet/AspNetCore)
<br><br>
## 部署前的配置
### 将留言通过 Smtp 转发至您的 Email
请访问项目根目录下的 appsettings.json 与 appsettings.Development.json 文件，按照注释补全您的 Email Smtp 信息。
<br><br>
请注意，appsettings.json 是正式部署时采用的设置，而 appsettings.Development.json 是 localhost 调试时采用的设置，通常他们的 Email 设置保持一致即可。如果您在调试时有特殊需求，则可以利用这一特性。
<br><br>
### 在 Kestrel 中启用 Https
如果您想使用 Kestrel 直接部署项目，并且启用 Https，可访问项目根目录下的 appsettings.json 与 Program.cs 文件，项目中已为您编写好了相应代码，只需根据注释进行修改即可。
<br><br>
Kestrel 是一个跨平台的适用于 ASP.NET Core 的 Web 服务器，已经包含在项目模板中。您可访问微软提供的[文档](https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/?view=aspnetcore-3.0)查看更多帮助。
