using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanAndreas.Application.Interfaces;
using SanAndreas.Application.Services;
using SanAndreas.Domain.Entities.Trechos.Interfaces.Services;
using SanAndreas.Domain.Entities.Trechos.Services;

namespace SanAndreas.Web
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
            services.AddMvc();

            services.AddTransient<IEncomendaApplicationService, EncomendaApplicationService>();
            services.AddTransient<ITrechoApplicationService, TrechoApplicationService>();

            services.AddTransient<IArmazenadorTrecho, ArmazenadorTrecho>();
            services.AddTransient<IBuscarTrechoCadastrado, BuscarTrechoCadastrado>();
            services.AddTransient<ICalcularRota, CalcularRota>();
            services.AddTransient<IRetornarTrechoDisponivel, RetornarTrechoDisponivel>();
            services.AddTransient<IValidadorFormatacaoTrecho, ValidadorFormatacaoTrecho>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
