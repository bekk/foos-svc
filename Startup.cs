using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data.SqlClient;


namespace foos_svc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
             options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddTransient(s => new SqlConnection(Configuration["ConnectionStrings:FoosDB"]));
            services.AddTransient<PlayersRepository>();
            services.AddTransient<MatchesRespository>();
            services.AddTransient<ScoresRepository>();
            services.AddTransient<TeamsRepository>();
            services.AddTransient<ResultsRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Database.Migrate(Configuration["ConnectionStrings:FoosDB"]);


            app.UseCors("AllowAll");

            app.UseMvc();



        }
    }
}
