using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Security.Authentication;

namespace CoreMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()

                //如果您希望启用Https，请先在appsetting.json中配置SSL证书，然后还原下方代码

                //.UseKestrel((context, serverOptions) =>
                //{
                //    serverOptions.Configure(context.Configuration.GetSection("Kestrel"))
                //        .Endpoint("HTTPS", listenOptions =>
                //        {
                //            listenOptions.HttpsOptions.SslProtocols = SslProtocols.Tls12;
                //        });
                //})
                ;
    }
}
