using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using covidpassbackend.Models;
using Microsoft.EntityFrameworkCore;
using covidpassbackend.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace covidpassbackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                     .AllowAnyHeader()));

            //Used for JWT Authentication - not done yet
            //services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            //services.AddAuthentication(options => {
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(jwt => {
            //    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

            //    jwt.SaveToken = true;
            //    jwt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true, // this will validate the 3rd part of the jwt token using the secret that we added in the appsettings and verify we have generated the jwt token
            //        IssuerSigningKey = new SymmetricSecurityKey(key), // Add the secret key to our Jwt encryption
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        RequireExpirationTime = false,
            //        ValidateLifetime = true
            //    };
            //});

            //services.AddDefaultIdentity<CovidPassContext>(options => options.SignIn.RequireConfirmedAccount = true)
            //                .AddEntityFrameworkStores<CovidPassContext>();

            //services.AddControllers();

            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "covidpassbackend", Version = "v1" });
            });

            services.AddDbContext<CovidPassContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("CovidPassContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "covidpassbackend v1"));
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
