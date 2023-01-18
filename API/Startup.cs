using System.Text.Json.Serialization;
using System;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            //builder.Services.AddScoped<IPublicacionRepository, PublicacionRepository>();
            services.AddScoped<IPublicacionRepository, PublicacionRepositorySP>();


            //Permite evitar los ciclos infinitos en las relaciones de clases
            //services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            
            //No muestra en la respuesta de la API los atributos que tienen como valor NULL, esto funciona con Controllers
            //services.AddControllers().AddJsonOptions(opciones => opciones.JsonSerializerOptions.DefaultIgnoreCondition
            //                = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);


            //Configuración de Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsRule", rule => {
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }

   

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsRule");

          
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
