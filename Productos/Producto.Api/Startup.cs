using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Producto.Core.Interfaces;
using Producto.Core.Services;
using Producto.Infrastructure.Data;
using Producto.Infrastructure.Filters;
using Producto.Infrastructure.Interfaces;
using Producto.Infrastructure.Repositories;
using Producto.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Api
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
            //Aqui añadimos el cors para habilitar permisos a React para la api
            services.AddCors();

            //Mapear desde la Capa Infrastructure
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Serializar el Json
            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).ConfigureApiBehaviorOptions(options =>
            {
                //Validando la clase Filters en Infrastructure
                options.SuppressModelStateInvalidFilter = true;
            });

            //Aplicacion de Inyeccion de Dependencia
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient(typeof(IRepository<>),typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider => {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            } );

            //Configurar el Filter
            services.AddMvc(options =>
            {
                //Llamado a la Carpeta Filter en infrastructure
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(option => {
                //Llamado de Distintas Validaciones en el metodo Validators(Infrastructure)
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //Añadimos el context de la base de Datos
            services.AddDbContext<ProductoApiContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Conexion")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Productos Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Aqui añadimos el cors para habilitar permisos a React para la api
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Producto.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
