var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//HTTP REQUEST ASSIGNMENT
//it's just a method that would be invoked with any request.
app.Run(async (HttpContext httpContext) =>
{
    if (httpContext.Request.Method == "GET")
    {
        httpContext.Response.Headers["Content-type"] = "text/html";
        if (httpContext.Request.Query.ContainsKey("firstNumber") &&
        httpContext.Request.Query.ContainsKey("secondNumber") &&
        httpContext.Request.Query.ContainsKey("operation"))
        {
            string? firstNumber = httpContext.Request.Query["firstNumber"];
            string? secondNumber = httpContext.Request.Query["secondNumber"];
            string? operation = httpContext.Request.Query["operation"];
            if (operation == "add")
            {
                await httpContext.Response.WriteAsync($"<p>{firstNumber} + {secondNumber} = {int.Parse(firstNumber) + int.Parse(secondNumber)}</p>");
            }
            else if (operation == "subtract")
            {
                await httpContext.Response.WriteAsync($"<p>{firstNumber} - {secondNumber} = {int.Parse(firstNumber) - int.Parse(secondNumber)}</p>");

            }
            else if (operation == "multiply")
            {
                await httpContext.Response.WriteAsync($"<p>{firstNumber} x {secondNumber} = {int.Parse(firstNumber) * int.Parse(secondNumber)}</p>");

            }
            else if (operation == "divide")
            {
                await httpContext.Response.WriteAsync($"<p>{firstNumber} / {secondNumber} = {int.Parse(firstNumber) / int.Parse(secondNumber)}</p>");
            }
            else
            {
                await httpContext.Response.WriteAsync($"invalid input for '{operation}'");
            }
        }
    }
});
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello");
});
app.Run();
