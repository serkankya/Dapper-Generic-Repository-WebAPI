using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Business.Abstract.DapperORM
{
    public interface IDapperContext
    {
        SqlConnection CreateConnection();
    }
}
