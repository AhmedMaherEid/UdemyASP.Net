var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        var header = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{header}</p>");
    }
});

app.Run();
