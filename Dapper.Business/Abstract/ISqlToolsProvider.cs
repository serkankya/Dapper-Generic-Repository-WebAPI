using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Business.Abstract
{
	public interface ISqlToolsProvider
	{
		string GetTableName<T>();
		(string?, string) GetKeyColumnAndPropertyName<T>();
		Dictionary<string, string> GetColumnAndPropertyNames<T>(bool key = true);
		string GetFormattedColumnsAndPropertyNames<T>(Dictionary<string, string> columnAndProperties, string format);
	}
}
