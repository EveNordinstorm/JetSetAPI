using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;
using JetSetAPI.Services;

namespace JetSetAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Add Services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<JsonFileService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
        }

        // Configures the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            // Serve static files from wwwroot (both API and frontend build files)
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = ""
            });

            // Handle React client-side routing by serving index.html for non-API routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Fallback to serve the React app's index.html
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
