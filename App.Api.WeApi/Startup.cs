using App.Api.Datos;
using App.Api.Datos.Interface;
using App.Api.Datos.Repositorio;
using App.Api.Model.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Api.WeApi
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            string StringConnection = Configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(StringConnection));

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
            services.AddScoped<IDetalleFacturaRepositorio, DetalleFacturaRepositorio>();
            //services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddCors(opctions =>
            {
                opctions.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
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
        }
    }
}
