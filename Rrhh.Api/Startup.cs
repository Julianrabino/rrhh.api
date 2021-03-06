﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Rrhh.Api.Exceptions;
using Rrhh.AppService.Services;
using Rrhh.Repository.Contexts;
using Rrhh.Repository.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Rrhh.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<EmployeeService>();
            services.AddTransient<EmployeeTypeService>();
            services.AddTransient<IdentificationTypeService>();
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<EmployeeTypeRepository>();
            services.AddTransient<IdentificationTypeRepository>();
            services.AddDbContext<EmployeeContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<EmployeeTypeContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<IdentificationTypeContext>(options =>
                options
                .UseLazyLoadingProxies()
                .UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "RRHH API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper();
        }

        private void OnShutdown()
        {
            MySqlConnection.ClearAllPools();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IApplicationLifetime applicationLifetime,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionMiddleware();
            }
            else
            {
                app.UseExceptionMiddleware();
                //app.UseExceptionHandler();
            }

            loggerFactory.AddConsole();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RRHH API V1");
                c.RoutePrefix = "docs";
            });


            applicationLifetime.ApplicationStopping.Register(OnShutdown);
            app.UseMvc();
        }
    }
}
