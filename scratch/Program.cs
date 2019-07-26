using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace scratch
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            //Allows the project to find the root directory for views etc.
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseKestrel()
            //Targets the Startup Class for startup directions
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }

    
}
