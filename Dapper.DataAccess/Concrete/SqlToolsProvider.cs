using Dapper.Business.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dapper.DataAccess.Concrete
{
	public class SqlToolsProvider : ISqlToolsProvider
	{
		public Dictionary<string, string> GetColumnAndPropertyNames<T>(bool key = true)
		{
			PropertyInfo[] properties = typeof(T).GetProperties();
			var columnAndPropertyDict = new Dictionary<string, string>();

			foreach (PropertyInfo property in properties)
			{
				if (property.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() is ColumnAttribute columnAttribute)
				{
					if (key || property.GetCustomAttributes(typeof(KeyAttribute), true).Length == 0)
					{
						if (columnAttribute.Name != null)
						{
							columnAndPropertyDict.Add(columnAttribute.Name, property.Name);
						}
					}
				}
				else
					throw new Exception($"Column is not found for property : {property.Name}");
			}

			return columnAndPropertyDict;
		}

		public string GetFormattedColumnsAndPropertyNames<T>(Dictionary<string, string> columnAndProperties, string format)
		{
			var res = string.Join(", ", columnAndProperties
			.Select(columnNamePropName =>
				string.Format(format, columnNamePropName.Key, columnNamePropName.Value)));

			return res;
		}

		public (string?, string) GetKeyColumnAndPropertyName<T>()
		{
			foreach (PropertyInfo properties in typeof(T).GetProperties())
			{
				if (properties.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0 && properties.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() is
					ColumnAttribute columnAttr)
				{
					return (columnAttr.Name, properties.Name);
				}
			}

			throw new Exception("Model does not contain the ColumnAttribute!");
		}

		public string GetTableName<T>()
		{
			var attributes = typeof(T).GetCustomAttributes(typeof(TableAttribute), true);

			if (attributes.Length > 0)
			{
				var tableAttribute = (TableAttribute)attributes[0];
				return tableAttribute.Name;
			}

			throw new Exception("Table not found.");
		}
	}
}
