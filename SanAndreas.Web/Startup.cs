using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanAndreas.Application.Interfaces;
using SanAndreas.Application.Services;
using SanAndreas.Domain.Entities.Encomendas.Interfaces;
using SanAndreas.Domain.Entities.Encomendas.Services;
using SanAndreas.Domain.Entities.Trechos.Interfaces;
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
            services.AddTransient<IBuscarMelhorRota, BuscarMelhorRota>();
            services.AddTransient<IBuscarTrechoCadastrado, BuscarTrechoCadastrado>();
            services.AddTransient<ICalcularRotaEncomenda, CalcularRotaEncomenda>();
            services.AddTransient<IConverterTrecho, ConverterTrecho>();
            services.AddTransient<IFiltrarTrechoValido, FiltrarTrechoValido>();
            services.AddTransient<IGerarSaidaEncomenda, GerarSaidaEncomenda>();
            services.AddTransient<IValidadorFormatacaoEncomenda, ValidadorFormatacaoEncomenda>();
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
