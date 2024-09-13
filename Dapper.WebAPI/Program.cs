using Dapper.DataAccess.Concrete.DapperORM;
using Dapper.WebAPI.Containers;

namespace Dapper.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.Configure<ContextOption>(builder.Configuration.GetSection(ContextOption.ConnectionString)); //Db

			builder.Services.ContainerDependencies(); //Containers --> Extensions

			var app = builder.Build();

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
