using System.Data.SqlClient;

namespace Dapper.Business.Abstract.DapperORM
{
	public interface IDapperContext
    {
        SqlConnection CreateConnection();
    }
}
