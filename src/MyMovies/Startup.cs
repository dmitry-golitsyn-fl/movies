﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace MyMovies
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            
            app.UseIISPlatformHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseMvc();
        }
    }
}
