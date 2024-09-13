using Dapper.Business.Abstract;
using Dapper.Business.Abstract.DapperORM;
using Dapper.DataAccess.Concrete;
using Dapper.DataAccess.Concrete.DapperORM;

namespace Dapper.WebAPI.Containers
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddTransient<IDapperContext, DapperContext>();
			services.AddTransient<ISqlToolsProvider, SqlToolsProvider>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		}
	}
}
