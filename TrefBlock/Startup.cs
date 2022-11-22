using AutoMapper;
using DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TrefBlock;
using System;
using System.Text;
using TrefBlock.Util;

namespace TrefBlock
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

            /*************************************************************************************************             
                            DB CONFIGURATION
            *************************************************************************************************/
            services.ConfigureSqlContext(Configuration);   // DB Context
            services.ConfigureRepositoryWrapper();         // Generic Repository
            services.ConfigureServiceWrapper();            // Generic Service

            /*************************************************************************************************             
                                                IDENTITY FRAMEWORK CONFIGURATION
            *************************************************************************************************/

            // UserManage and SignInManager Injection into any class constructor
            services
                .AddDefaultIdentity<User>()   // Adds common services from identity core into application, default identity from the model
                .AddRoles<IdentityRole>() // Add Roles
                .AddEntityFrameworkStores<TrefBlockDbContext>();   // Adds ef implemetation of identity core

            // Identity requirement options
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;

            }
            );

            /*************************************************************************************************             
                                                CORS CONFIGURATION
             *************************************************************************************************/
            // If CORS is needed, instal Microsoft.AspNetCore.Cors
            // services.AddCors(); && app.UseCors(builder => builder.withOrigins("URL").AllowAnyHeader().AllowAnyMethod()) in Configure Method

            /*************************************************************************************************             
                                                JWT SECURITY CONFIGURATION
             *************************************************************************************************/

            // JWT Secret Code
            var jwtKey = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JwtSecret"].ToString());

            //JWT Authentication Configuration
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // Doesn't require HTTPS
                x.SaveToken = false; // Don't save token in server after successfull auth
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, //Validate security key during token validation
                    IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                    ValidateIssuer = false,   // If we want to validate issuer (Server)
                    ValidateAudience = false,  // If we want to validate previously targeted auidence
                    ClockSkew = TimeSpan.Zero  // No diference between client/server TZ (expiration relevant)
                };
            });

            /*************************************************************************************************             
                                                MISC
            *************************************************************************************************/

            // Inject Application Settings configuration - appsettings.json/ApplicationSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // AutoMapper *****************************************************************************
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            // End of AutoMapper config

            // JSON serializer configuration ************************************************************
            services.AddControllers().AddNewtonsoftJson(
                o => o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            );

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseAuthentication(); // Identity EF

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
