using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CoreApp.Configuration;
using CoreApp.Extensions;
using CoreApp.Middleware;
using CoreApp.Repository;
using CoreApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreApp
{
    public class Startup
    {        

        /// <summary>
        /// Hello
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherDao, WeatherDaoImp>();
            services.AddScoped<IWeatherService, WeatherServiceImp>();
            services.AddScoped<IWeatherServiceAsync, WeatherServiceImpAsync>();
            services.AddScoped<IWeatherBusiness, WeatherBusinessImpl>();
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title= "WideWorldImporters API", Version = "v1" });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Set xml path
                options.IncludeXmlComments(xmlPath);
            });

            ConfigureSections(services);
            services.AddControllers();
            //services.AddControllers(options =>
            //options.Filters.Add(new HttpResponseExceptionFilter()));
        }

        private void ConfigureSections(IServiceCollection services)
        {
            services.Configure<ApplicationConfig>(Configuration.GetSection(nameof(ApplicationConfig)));
            services.Configure<UserConfig>(Configuration.GetSection(nameof(UserConfig)));
            //services.Configure<KestrelServerOptions>(
            //Configuration.GetSection("Kestrel"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<FeatureSwitchMiddleware>();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-local-development");
                //app.UseExceptionHandler("/Error");

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseCustomExceptionHandler();

            // 
            //app.UseMvc(routes => {
            //        routes.MapRoute("blog", "blog/{*article}",defaults: new { controller = "Blog", action = "Article" });
            //        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // app.UseCookiePolicy();

            app.UseRouting();

            // app.UseRequestLocalization();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
            // app.UseSession();

            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest2);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WideWorldImporters API V1");
            });

            //app.UseCustomMvc();

            app.UseEndpoints(endpoints =>
            {
                // Configure the Health Check endpoint and require an authorized user.
               // endpoints.MapHealthChecks("/healthz").RequireAuthorization();

                endpoints.MapGet("/hello/{name:alpha}", async context =>
                {
                    var name = context.Request.RouteValues["name"];
                    await context.Response.WriteAsync($"Hello {name}!");
                });

                //endpoints.MapGet("/", async context =>
                //{
                    
                //    await context.Response.WriteAsync("Page par defautl vide!");
                //});


                endpoints.MapControllerRoute(name: "/", pattern: "{controller=WeatherForecast}/{action=Get}/{id?}");


            });
        }

        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

    }
}
