using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhonePlan.Application;
using PhonePlan.Crud.Api.Filters;
using PhonePlan.Crud.Api.Pipelines;
using PhonePlan.Domain;
using System.Globalization;

namespace PhonePlan.Crud
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
			services.ApplicationInject();
			services.DomainInject();

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipeline<,>));

			ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

			services.AddControllers(opt =>
			{
				opt.Filters.Add<ExceptionFilter>();
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhonePlan.Crud", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();				
			}

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhonePlan.Crud v1"));

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
