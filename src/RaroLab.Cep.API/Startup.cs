using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RaroLab.Cep.API.Services;
using RaroLab.Cep.API.Services.Interfaces;
using RaroLab.Cep.API.Swagger;
using RaroLab.Cep.Domain.Interfaces;
using RaroLab.Cep.Infra.Services;
using System;
using System.Net.Http.Headers;

[assembly: ApiConventionType(typeof(MyApiConventions))]
namespace RaroLab.Cep.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RaroLab.Cep.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddHttpContextAccessor();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RaroLab.Cep.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();

            services.AddHttpClient<IViaCepService, ViaCepService>((s, c) =>
            {
                var httpContext = s.GetService<IHttpContextAccessor>().HttpContext;
                c.BaseAddress = new Uri(Configuration["Apis:ViaCep"]);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
