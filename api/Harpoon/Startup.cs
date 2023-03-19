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
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using HotChocolate.Types;

using O8Query.Models;
using O8Query.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Harpoon
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors( o => {
                o.AddDefaultPolicy(b => {
                    b.WithOrigins(new string[] { "http://localhost:8080" })
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddScoped<IdentityService>();
            // services.AddHttpContextAccessor();

            string connectionString = string.Format("Server={0},{1};Database={2};Persist Security Info=True;User ID={3};Password={4};", 
                        Environment.GetEnvironmentVariable("HARPOON_DB_HST"),
                        Environment.GetEnvironmentVariable("HARPOON_DB_PRT"),
                        Environment.GetEnvironmentVariable("HARPOON_DB_DB"),
                        Environment.GetEnvironmentVariable("HARPOON_DB_USR"),
                        Environment.GetEnvironmentVariable("HARPOON_DB_PWD"));

            services.AddControllers();
            services.AddDbContext<BlobQuery>(
                options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Harpoon")));
                
            services.AddPooledDbContextFactory<StocksQuery>(
                (s, o) => 
                    o
                        .UseSqlServer(connectionString, b => b.MigrationsAssembly("Harpoon"))
                        .EnableSensitiveDataLogging() // TODO: For debugging purposes
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>())
                )
                .AddGraphQLServer()
                .SetPagingOptions(new HotChocolate.Types.Pagination.PagingOptions{ DefaultPageSize = 20, MaxPageSize = 500, IncludeTotalCount = true })
                // TODO: For debugging purposes. Credit https://stackoverflow.com/questions/65764361/how-can-i-get-more-error-details-or-logging-when-an-exception-is-thrown-in-a-ho
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _env.IsDevelopment())
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<StatementAnalyteType>()
                .AddType<StatementAnalyteInputType>()
                .AddType<UploadType>()
                .AddTypeConverter<List<StatementAnalyte.Assay>, StatementAnalyte.Assay>(from => EnumExtension.ToCombined<StatementAnalyte.Assay>(from))
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddMaxExecutionDepthRule(7, skipIntrospectionFields: true)
                .AddMutationConventions()
                .AddAuthorization();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:5001/",
                        ValidAudience = "www",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B3atiful$undayMorning"))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints( endpoints => 
                {
                    endpoints.MapControllers();
                    endpoints.MapGraphQL();
                });
        }
    }
}
