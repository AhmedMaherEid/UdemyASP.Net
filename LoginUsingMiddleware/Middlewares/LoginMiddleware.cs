
using LoginUsingMiddleware.Helpers;
using Microsoft.Extensions.Primitives;
using System.Runtime.CompilerServices;

namespace LoginUsingMiddleware.Middlewares
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "POST" && context.Request.Path == "/")
            {
                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

                //you must parse the body into dictionary<string, StringValues> before using
                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(requestBody);

                if (queryDict.Count == 0)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email'\n");
                    await context.Response.WriteAsync("Invalid input for 'password'");
                }
                else if (queryDict.ContainsKey("email"))
                {
                    if (queryDict["email"].FirstOrDefault() == EmailHelper.AdminEmail)
                    {
                        if (queryDict.ContainsKey("password"))
                        {
                            if (queryDict["password"].FirstOrDefault()?.ToString() == EmailHelper.AdminPassword)
                            {
                                context.Response.StatusCode = 200;
                                await context.Response.WriteAsync("Sucessful Login");
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input for 'password'");
                        }
                    }
                    else if (queryDict.ContainsKey("password"))
                    {
                        if (queryDict["password"].FirstOrDefault() != EmailHelper.AdminPassword)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid Login");
                        }

                    }
                }
                else if (!queryDict.ContainsKey("password"))
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("No Response");
                }
                else if (queryDict.ContainsKey("password"))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'");
                }
            }
            await _next(context);
        }
    }
}
