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

using O8Query.Data;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Harpoon", Version = "v1" });
            });

            string connectionString = Configuration.GetConnectionString("HarpoonDatabase");

            services.AddPooledDbContextFactory<StocksQuery>(
                options => 
                    options
                        .UseSqlServer(connectionString, b => b.MigrationsAssembly("Harpoon"))
                )
                .AddGraphQLServer()
                // For debugging purposes. Credit https://stackoverflow.com/questions/65764361/how-can-i-get-more-error-details-or-logging-when-an-exception-is-thrown-in-a-ho
                .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _env.IsDevelopment())
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Harpoon v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints( endpoints => 
                {
                    //endpoints.MapControllers();
                    endpoints.MapGraphQL();
                });
        }
    }
}
