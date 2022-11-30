using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ReservationBackend;
using ReservationBackend.Services;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ReservationBackend.API
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


        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; " +
        "AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\DB\RBDatabase.mdf;" +
        " Integrated Security=True; Connect Timeout=30;";

        services.AddDbContext<ReservationBackend.Data.RBDBContext>(options =>
             options.UseSqlServer(connectionString));

            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservation Backend v1");
            });

        }
    }
}
