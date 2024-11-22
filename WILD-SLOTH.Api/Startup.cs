using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WILD.SLOTH.Data;
using WILD.SLOTH.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace WILD.SLOTH.Api
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
            var builder = WebApplication.CreateBuilder(args);

            String authority = builder.Configuration["Auth0:Authority"] ??
                throw new ArgumentNullException("Auth0:Authority");

            String audience = builder.Configuration["Auth0:Audience"] ??
                throw new ArgumentNullException("Auth0:Audience");

            services.AddControllers();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(Options =>
                {
                    options.Authority = authority;
                    Options.Audience = audience;
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("delete:catalog", policy =>
                    policy.RequireAuthenticatedUser().RequireClaim("scope", "delete:catalog"));
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source=../Registrar.sqlite",
                    b => b.MigrationsAssembly("WILD.SLOTH.Api")));
            services.AddCors(options =>
{
options.AddDefaultPolicy(policyBuilder =>
{
policyBuilder.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod();
});
});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WILD.SLOTH.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
