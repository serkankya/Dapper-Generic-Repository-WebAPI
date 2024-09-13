using Dapper.Business.Abstract.DapperORM;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Dapper.DataAccess.Concrete.DapperORM
{
	public class DapperContext : IDapperContext
    {
		private readonly ContextOption _contextOption;

		public DapperContext(IOptions<ContextOption> options)
		{
			_contextOption = options.Value;
		}	

		public SqlConnection CreateConnection()
		{
			return new SqlConnection(_contextOption.Connection);
		}
	}
}
