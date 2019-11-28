# core-me

core-me 是一个敲可爱的自我介绍网站，带有留言功能。

戳这里查看👉 [示例网站](https://surbowl.online)


## 语言&框架 👨‍💻
- C#
- HTML
- CSS
- JS
- [Bulma](https://github.com/jgthms/bulma)
- [ASP.NET Core 2.1 MVC](https://github.com/aspnet/AspNetCore)


## 部署前的配置 🔧

### 将留言通过Smtp转发至Email

请访问 Controllers/HomeController.cs 文件，在 private bool SendEMail(string subject, string body) 方法中补充与修改您的smtp设置。

### 启用Https

如果您想直接使用 Kestrel 部署项目，并且启用 Https，可访问项目根目录下的 appsettings.json 与 Program.cs 文件，根据注释进行操作。

Kestrel 是一个跨平台的适用于 ASP.NET Core 的 Web 服务器，已经包含在项目模板中。

可访问微软提供的[文档](https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/?view=aspnetcore-3.0)查看更多帮助。
