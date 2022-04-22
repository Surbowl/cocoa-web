namespace Cocoa.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true)
                        .AddResponseCompression()
                        .AddControllersWithViews()
                        .AddNewtonsoftJson();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseResponseCompression()
               .UseExceptionHandler("/Home/Error");

            if (app.Environment.IsProduction())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }
        }

        app.UseStaticFiles()
           .UseRouting()
           .UseEndpoints(endpoints =>
           {
               endpoints.MapControllerRoute(
                   name: "spa-route",
                   pattern: "{controller}/{*anything=Index}",
                   defaults: new { action = "Index" });

               endpoints.MapDefaultControllerRoute();
           });

        app.Run();
    }
}