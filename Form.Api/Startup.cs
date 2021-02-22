using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Form.Repository.Api.Infrastructure;
using Form.Repository.Api.Repository;
using Microsoft.Extensions.Options;
using Form.Buisness.Api;
using Form.Buisness.Api.Infrastructure;
using Form.Buisness.Api.Mapper;
using AutoMapper;
using Form.Repository.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Form.Api
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
            services.AddControllers();

            services.Configure<FormDatabaseSettings>(Configuration.GetSection(nameof(FormDatabaseSettings)));


            services.AddSingleton<IFormDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<FormDatabaseSettings>>().Value;
            });

            services.Configure<HobbiesDatabaseSettings>(Configuration.GetSection(nameof(HobbiesDatabaseSettings)));


            services.AddSingleton<IHobbiesDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<HobbiesDatabaseSettings>>().Value;
            });


            services.AddScoped<IFormContext, FormContext>();
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormBuisness, FormBuisness>();

            services.AddScoped<IHobbiesContext, HobbiesContext>();
            services.AddScoped<IHobbiesRepository, HobbiesRepository>();
            services.AddScoped<IHobbyBuisness, HobbyBuisness>();
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MapperClass>(), typeof(Startup));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Form.Api", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Form.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
