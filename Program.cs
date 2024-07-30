using StockNotificationApp.Models;
using StockNotificationApp.StockHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<StockChecker>();

var app = builder.Build();




// static files
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "index.html" }
});
app.UseStaticFiles();

app
    .UseRouting()
    .UseEndpoints(endpoints =>
{
    endpoints.MapHub<StockHub>("/stockHub");

    endpoints.MapGet("/api/notifyClientReady", async context =>
    {
        var stockChecker = app.Services.GetRequiredService<StockChecker>();
        var products = new List<Product>
        {
            new Product("Product A", 10),
            new Product("Product B", 5),
            new Product("Product C", 2)
        };
        stockChecker.CheckStock(products, 3);
        await context.Response.WriteAsync("Client ready notification received.");
    });
});

app.Run();