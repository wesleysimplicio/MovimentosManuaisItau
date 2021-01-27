using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using MovimentosManuais.ApplicationCore.Services;
using MovimentosManuais.InfraStruture.Data;
using MovimentosManuais.InfraStruture.Repository;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.IO;

namespace MovimentosManuais.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            services.AddScoped<IMovimentoManualService, MovimentoManualService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoCosifService, ProdutoCosifService>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<MovimentosManuaisContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Movimento Manuais",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Wesley Simplicio",
                            Url = new Uri("https://github.com/wesleysimplicio")
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddMvcCore(options =>
                 {
                     options.RequireHttpsPermanent = true; // does not affect api requests
                     options.RespectBrowserAcceptHeader = true; // false by default
                 })
                //.AddApiExplorer()
                //.AddAuthorization()
                .AddFormatterMappings()
                //.AddCacheTagHelper()
                //.AddDataAnnotations()
                //.AddCors()
                .AddJsonFormatters(); // JSON, or you can build your own custom one (above)
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            LogManager.LoadConfiguration("nlog.config");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("default");
            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Movimentos Manuais");
            });
        }
    }
}
