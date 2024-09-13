using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.DataAccess.Concrete.DapperORM
{
	public class ContextOption
	{
		public const string ConnectionString = "ConnectionStrings";

		public string Connection { get; set; } = string.Empty;
	}
}
