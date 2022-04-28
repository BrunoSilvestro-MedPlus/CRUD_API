using CRUD_API.IServices;
using CRUD_API.Models;
using CRUD_API.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API
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
             // Documentação
            services.AddSwaggerGen(cfg =>
            {
                var contact = new OpenApiContact
                {
                    Name = "Documentação"                
                };

                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CRUD API 1.0",
                    Contact = contact
                });

               

            });

            services.AddControllers()
           .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllers();
            services.AddHttpClient();
            services.AddDbContext<CrudContext>(options =>
                options.UseSqlServer(Configuration["DbConnection"]));

            // Contratos e classes concretas da aplicação

            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProdutosCategoriasService, ProdutosCategoriasService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app
              .UseSwagger()
              .UseSwaggerUI(s =>
              {
                  s.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                  s.DisplayRequestDuration();
                  s.DisplayOperationId();
                  s.EnableValidator();
                  s.DefaultModelExpandDepth(2);
                  s.DefaultModelRendering(ModelRendering.Model);
                  s.DefaultModelsExpandDepth(-1);
                  s.DocExpansion(DocExpansion.None);
                  s.EnableDeepLinking();
                  s.ShowExtensions();
                  s.RoutePrefix = "swagger";
                  s.DocumentTitle = "Avaliação Sponte";
              });
        }
    }
}
