using Business;
using Business.BO;
using Business.Interface;
using Business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Database;
using Repository.Interface;
using Repository.Repositories;
using System;

namespace API
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

            services.AddDbContext<LocacaoDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"));

            services.AddScoped<IClienteBO, ClienteBO>();
            services.AddScoped<IFilmeBO, FilmeBO>();
            services.AddScoped<ILocacaoBO, LocacaoBO>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Locadora WiPro",
                        Version = "v1",
                        Description = "Web API Locadora WiPro",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Gerson Viana",
                            Url = new Uri("https://www.linkedin.com/in/gerson-viana-1126178b/", UriKind.Absolute)
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Web API Locadora WiPro");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
