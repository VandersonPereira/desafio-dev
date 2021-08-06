using ByCoders.ParseCNAB.Dados.Contextos;
using ByCoders.ParseCNAB.Dados.Repositorios;
using ByCoders.ParseCNAB.Dados.Transacoes;
using ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ByCoders.ParseCNAB.API
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
#if DEBUG
            services.AddCors();
#endif
            services.AddDbContext<MovimentacaoFinanceiraContexto>(optios => optios.UseSqlServer(Configuration.GetConnectionString("ByCodersConnection")).EnableSensitiveDataLogging());

            services.AddScoped<MovimentacaoFinanceiraContexto, MovimentacaoFinanceiraContexto>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IMovimentacaoFinanceiraRepositorio, MovimentacaoFinanceiraRepositorio>();

            services.AddTransient<CriarMovimentacaoFinanceiraComandoManipulador, CriarMovimentacaoFinanceiraComandoManipulador>();
            services.AddTransient<ListarMovimentacaoFinanceiraComandoManipulador, ListarMovimentacaoFinanceiraComandoManipulador>();

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#if DEBUG
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
#endif
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
