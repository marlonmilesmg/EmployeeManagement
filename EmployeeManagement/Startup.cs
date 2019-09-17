using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddMvc().AddXmlDataContractSerializerFormatters();  // To return data in xml format add AddXmlDataContractSerializerFormatters()
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env /* Logger Injection, ILogger<Startup> logger */)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            // Use Default page Index.html or Default.html
           // app.UseDefaultFiles();
            app.UseStaticFiles();
             app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //    {
            //        routes.MapRoute("default", "marlon/{controller=Home}/{action=Index}/{id?}");
            //    });



            /*   // Opening another page as default instead of the Default page using DefaultFileOptions Middleware {
               DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
               defaultFilesOptions.DefaultFileNames.Clear();
               defaultFilesOptions.DefaultFileNames.Add("foo.html");
               app.UseDefaultFiles(defaultFilesOptions);
               app.UseStaticFiles();
               // } */

            /*  // Opening Default Page using FileServer Middleware {
             DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
             defaultFilesOptions.DefaultFileNames.Clear();
             defaultFilesOptions.DefaultFileNames.Add("foo.html");
             app.UseFileServer();
             // } */

            /* // Opening another file as default page Using FileServer Middleware {
            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fileServerOptions);
            // } */

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Development Environment: " + env.EnvironmentName);
            });

        // Request Processing Pipeline Middleware {
        /*    app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and response produced");
                logger.LogInformation("MW3: Request handled and response produced");
            });

            // } to this part */


        }
    }
}
