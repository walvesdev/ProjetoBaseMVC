using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBase.AcessoDados;
using ProjetoBaseMVC.Controllers;
using ProjetoBaseMVC.Dados.AcessoDados.Repositorios;
using ProjetoBaseMVC.Model.Models;
using ProjetoBaseMVC.Model.Validations;

namespace ProjetoBaseMVC
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
            //services.AddTransient<ValidationResult>();
            services.AddTransient<ApplicationContext>();
            services.AddTransient<EmpresaRepositorio>();
            services.AddTransient<EmpresaController>();


            //DbContext postgres
            string connectionSrting = Configuration.GetConnectionString("ApplicationContext");

            services.AddDbContext<ApplicationContext>((optBuilder) => { optBuilder.UseSqlServer(connectionSrting); });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddDataProtection().UnprotectKeysWithAnyCertificate();

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Empresa>, EmpresaValidator>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Empresa}/{action=Create}/{id?}");
            });
        }
    }
}
