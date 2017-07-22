using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using AspNetCoreDemo.Services;
using AspNetCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspNetCoreDemo
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // IGreeter is a custom service that needs to added to ConfigureServices
            // Remember - the Configure() method is injectable
            // IGreeter is injected as the last argument
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton(Configuration);
            services.AddMvc();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddDbContext<AspNetCoreDemoDbContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("AspNetCoreDemo")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AspNetCoreDemoDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // IApplicationBuilder, IHostingEnv, and ILoggerFactory are all provided by ASP.NET
        // native to the IServicesCollection services
        public void Configure(IApplicationBuilder app, 
                                IHostingEnvironment env, 
                                ILoggerFactory loggerFactory,
                                IGreeter greeter)
        {
            loggerFactory.AddConsole();
            
            
            // UseDeveloperExceptionPage needs to come/be installed before other pieces of middleware
            // otherwise it won't be initiated
            // req/res cycle won't hit it
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler(new ExceptionHandlerOptions
            //    {
            //        ExceptionHandler = context => context.Response.WriteAsync("Opps!")
            //    });
            //}

            app.UseFileServer();

            app.UseNodeModules(env.ContentRootPath);

            app.UseIdentity();

            app.UseMvc(ConfigureRoutes);

            //app.Run(ctx => ctx.Response.WriteAsync("Not Found"));

            // will use default files in the webroot
            // index.html is a automaticall configured as default file name
            // UseDefaultFile has to come before UseStaticFiles
            //app.UseDefaultFiles();
            
            
            // NuGet package Microsoft.AspNetCore.StaticFiles
            // looks for files in the wwwroot "web root" directory
            //app.UseStaticFiles();


            // Combines the UseDefaultFiles and UseStaticFiles middleware

//------THIS SECTION USED TO DEMONSTRATE MIDDLEWARE - NOT RELEVANT TO ASP.NET CORE MVC-----------------
            // if incoming request contains "/welcome" in path - triggers welcome page middleware
            //app.UseWelcomePage("/welcome");
            
            
            //// same this as above - different methodology - oop
            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/welcome"
            //});


            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Somthing happened - call Clint!");
            //    //var message = Configuration["Greeting"];
            //    var message = greeter.GetGreeting();
            //    for (int i = 0; i <= 10; i++)
            //    {
            //        await context.Response.WriteAsync("Hello World! Now get Schwifty!\n" + message + ": " + i.ToString()+"\n");
            //    }
            //});
//-------------------------------------------------------------------------------------------------------


        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //This is Convention Based Routing

            // /Home/Index/(somethig else [? = optional])
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }

    }
}
