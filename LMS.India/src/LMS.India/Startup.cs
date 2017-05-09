using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LMS.India.Repository;
using Microsoft.EntityFrameworkCore;
using LMS.India.Controllers.JWT;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace LMS.India
{
    public class Startup
    {
        private const string SecretKey = "lMsinDia123456789";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Use policy auth.
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AuthorizeUser",
            //                      policy => policy.RequireClaim("Authorization", "lMsIndiA20162017"));
            //});

            // Add framework services.
           // services.AddOptions();

            // Get options from app settings
            //var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            //// Configure JwtIssuerOptions
            //services.Configure<JwtIssuerOptions>(options =>
            //{
            //    options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            //    options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
            //    options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            //});

            services.AddDbContext<EntityDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("lmsConnections")));
            //services.AddCors(options =>
            //{
            //        options.AddPolicy("AllowAllOrigin",
            //        builder => builder
            //                        .AllowAnyOrigin()
            //                        .AllowAnyMethod()
            //                        .AllowAnyHeader()
            //                        .AllowCredentials());
            //});
            var _policy = new CorsPolicy();

            _policy.Headers.Add("*");
            _policy.Methods.Add("*");
            _policy.Origins.Add("*");
            _policy.SupportsCredentials = true;

            services.AddCors(action => action.AddPolicy("AllowAllOrigin", _policy));
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add framework services.
            // Make authentication compulsory across the board (i.e. shut
            // down EVERYTHING unless explicitly opened up).
            //services.AddMvc(config =>
            //{
            //    var _allowpolicy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //    config.Filters.Add(new AuthorizeFilter(_allowpolicy));
            //});

            services.AddMvc();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, EntityDBContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("AllowAllOrigin");
            //var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

            //    ValidateAudience = true,
            //    ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = _signingKey,

            //    RequireExpirationTime = true,
            //    ValidateLifetime = true,

            //    ClockSkew = TimeSpan.Zero
            //};

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});
            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
            DbInitializer_SeedData.Initialize(context);

        }
    }
}
