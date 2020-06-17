using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using CineManagerBlazor.Server.Data;
using CineManagerBlazor.Server.Models;
using AutoMapper;
using CineManagerBlazor.Server.Services;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CineManagerBlazor.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;

                // provedor personalizado dos tokens de usuario de identidade - 1 dia é o padrao
                options.Tokens.ProviderMap.Add("CustomEmailConfirmacao",
                    new TokenProviderDescriptor(typeof(CustomEmailTokenProv<IdentityUser>)));

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmacao";
            }).AddEntityFrameworkStores<AppDbContext>();

            //Seriço de personalização do token
            services.AddTransient<CustomEmailTokenProv<IdentityUser>>();


            //Vida do token de segurança do email - identidade interna
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(3));

            //Autenticacao email e senha
            services.AddTransient<IEmailSender, SenderEmailConfirmacao>();
            services.Configure<EmailConfirmacao>(Configuration);

            //Inatividade padrao de 14 dias, mudando para 7 dias
            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromDays(7);
                o.SlidingExpiration = true;
            });

            services.AddIdentityServer()
                .AddApiAuthorization<IdentityUser, AppDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //Autenticação do Google
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAutentication = Configuration.GetSection("Authentication:Google");

                options.ClientId = googleAutentication["ClientId"];
                options.ClientSecret = googleAutentication["ClientSecret"];
            }).AddFacebook(facebookOptions => // Autenticação do Facebook
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });



            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
