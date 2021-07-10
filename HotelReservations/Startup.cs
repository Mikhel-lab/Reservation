using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies.Backup;
using HotelReservation.Domain.Configuration;
using HotelReservation.Repositories.Implemetation;
using HotelReservation.Repositories.Interface;
using HotelReservation.Service.Services.EmailService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelReservations
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
		    //services.AddHangfireServer();
			services.AddSingleton<IDbClient, DbClient>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IReservationRepository,ReservationRepository>();
			services.AddTransient<IDashboardRepository, DashboardRepository>();
			services.AddTransient<IRoomRepository, RoomRepository>();
			services.Configure<HotelReservationConfig>(Configuration);
			services.AddTransient<IEmailSending, EmailSending>();
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel Reservation Service", Version = "v1" });
				

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					In = ParameterLocation.Header,
					Description = "Authorization format : Bearer {token}",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "Bearer",
							Name = "Bearer",
							In = ParameterLocation.Header,

						},
						new List<string>()
					}
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			//app.UseHangfireDashboard();
			app.UseRouting();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				string prefix = string.IsNullOrEmpty(c.RoutePrefix) ? "." : "..";
				c.SwaggerEndpoint($"{prefix}/swagger/v1/swagger.json", "Hotel Reservation Service v1");
			});

			app.UseAuthorization();
			//app.UseHangfireDashboard();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
