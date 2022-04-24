var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddResponseCompression();
builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseResponseCompression();

    app.UseExceptionHandler("/Home/Error");

    //if (app.Environment.IsProduction())
    //{
    //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //    app.UseHsts();
    //    app.UseHttpsRedirection();
    //}
    //else if (env.EnvironmentName == "ProductionWithoutSsl")
    //{

    //}
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
   {
       endpoints.MapControllerRoute(
           name: "spa-route",
           pattern: "{controller}/{*anything=Index}",
           defaults: new { action = "Index" });

       endpoints.MapDefaultControllerRoute();
   });

app.Run();