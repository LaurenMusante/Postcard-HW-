using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendLetter
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) // This constructor will create an iteration of the Startup class that contains specific settings and variables to run our project successfully. It's required for configuring a basic ASP.NET Core MVC project.
            {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            }

            public IConfigurationRoot Configuration { get; }

            public void ConfigureServices(IServiceCollection services) //ConfigureServices() is a required built-in method used to set up an application's server. 
                {
                services.AddMvc();
                }
            public void Configure(IApplicationBuilder app) //The Configure() method is built-in and required in all ASP.NET Core apps. ASP.NET calls Configure() when the app launches. It's responsible for telling our app how to handle requests to the server.
                {
                    app.UseDeveloperExceptionPage();  //This will produce a friendly error report when Razor fails to load.
                    app.UseMvc(routes => // tells our app to use the MVC framework to respond to HTTP requests. This block of code also sets up default routing for our application. It tells the project to use the Index action of the Home Controller as the default route. This will be our homepage. 
                    {
                        routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                    });

                    app.Run(async (context) => //The second block, which starts with app.Run(...), is not actually required to successfully launch our project. However, it will allow us to test that our Configure() method is working properly. 
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                }
    }

}


//We've also created a new file that we didn't use last week: Startup.cs. This file is required in every ASP.NET MVC Core project. It provides instructions on compiling and running a web application. We'll add code to ours one step at a time. This code is complex but there's no need to memorize it. This code will very similar for future projects as well.

