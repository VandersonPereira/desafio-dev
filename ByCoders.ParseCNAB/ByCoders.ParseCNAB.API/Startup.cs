using ByCoders.ParseCNAB.Dados.Contextos;
using ByCoders.ParseCNAB.Dados.Repositorios;
using ByCoders.ParseCNAB.Dados.Transacoes;
using ByCoders.ParseCNAB.Dominio.Comandos.Manipuladores;
using ByCoders.ParseCNAB.Dominio.Compartilhado;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;

namespace ByCoders.ParseCNAB.API
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
            var key = Encoding.ASCII.GetBytes(Configuracoes.ChaveSecreta);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddCors();
            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Movimentação Financeira - ByCoders_", Version = "v1" });
                x.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddDbContext<MovimentacaoFinanceiraContexto>(optios => optios.UseSqlServer(Configuration.GetConnectionString("ByCodersConnection")).EnableSensitiveDataLogging());

            services.AddScoped<MovimentacaoFinanceiraContexto, MovimentacaoFinanceiraContexto>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IMovimentacaoFinanceiraRepositorio, MovimentacaoFinanceiraRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddTransient<CriarMovimentacaoFinanceiraComandoManipulador, CriarMovimentacaoFinanceiraComandoManipulador>();
            services.AddTransient<ListarMovimentacaoFinanceiraComandoManipulador, ListarMovimentacaoFinanceiraComandoManipulador>();
            services.AddTransient<LoginMovimentacaoFinanceiraComandoManipulador, LoginMovimentacaoFinanceiraComandoManipulador>();

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
