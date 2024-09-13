
using Dapper.Business.Abstract;
using Dapper.Business.Abstract.DapperORM;
using Dapper.DataAccess.Concrete;
using Dapper.DataAccess.Concrete.DapperORM;
using Dapper.WebAPI.Containers;

namespace Dapper.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.Configure<ContextOption>(builder.Configuration.GetSection(ContextOption.ConnectionString));

			builder.Services.ContainerDependencies();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
