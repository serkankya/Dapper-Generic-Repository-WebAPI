namespace Dapper.DataAccess.Concrete.DapperORM
{
	public class ContextOption
	{
		//appsettings.json --> Dapper.WebAPI
		public const string ConnectionString = "ConnectionStrings";

		public string Connection { get; set; } = string.Empty;
	}
}
