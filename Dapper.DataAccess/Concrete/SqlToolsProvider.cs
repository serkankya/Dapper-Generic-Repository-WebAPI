using Dapper.Business.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Dapper.DataAccess.Concrete
{
	public class SqlToolsProvider : ISqlToolsProvider
	{
		/// <summary>
		/// Gets a dictionary of column names and their corresponding property names for the given type.
		/// </summary>
		/// <typeparam name="T">The type to inspect.</typeparam>
		/// <param name="key">Indicates whether to include key properties. Defaults to true.</param>
		/// <returns>A dictionary where the key is the column name and the value is the property name.</returns>
		/// <exception cref="Exception">Thrown if a property does not have a ColumnAttribute.</exception>
		public Dictionary<string, string> GetColumnAndPropertyNames<T>(bool key = true)
		{
			PropertyInfo[] properties = typeof(T).GetProperties();
			var columnAndPropertyDict = new Dictionary<string, string>();

			foreach (PropertyInfo property in properties)
			{
				// Check if the property has a ColumnAttribute
				if (property.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() is ColumnAttribute columnAttribute)
				{
					// Include key properties if specified, or exclude if not
					if (key || property.GetCustomAttributes(typeof(KeyAttribute), true).Length == 0)
					{
						if (columnAttribute.Name != null)
						{
							columnAndPropertyDict.Add(columnAttribute.Name, property.Name);
						}
					}
				}
				else
				{
					// Throw an exception if the ColumnAttribute is missing
					throw new Exception($"Column is not found for property: {property.Name}");
				}
			}

			return columnAndPropertyDict;
		}

		/// <summary>
		/// Formats the column and property names into a string using the specified format.
		/// </summary>
		/// <typeparam name="T">The type to inspect.</typeparam>
		/// <param name="columnAndProperties">A dictionary of column names and property names.</param>
		/// <param name="format">The format string to apply.</param>
		/// <returns>A formatted string of columns and property names.</returns>
		public string GetFormattedColumnsAndPropertyNames<T>(Dictionary<string, string> columnAndProperties, string format)
		{
			var res = string.Join(", ", columnAndProperties
				.Select(columnNamePropName =>
					string.Format(format, columnNamePropName.Key, columnNamePropName.Value)));

			return res;
		}

		/// <summary>
		/// Gets the column name and property name for the key property of the given type.
		/// </summary>
		/// <typeparam name="T">The type to inspect.</typeparam>
		/// <returns>A tuple containing the column name and property name of the key property.</returns>
		/// <exception cref="Exception">Thrown if no key property is found or if the property does not have a ColumnAttribute.</exception>
		public (string?, string) GetKeyColumnAndPropertyName<T>()
		{
			foreach (PropertyInfo properties in typeof(T).GetProperties())
			{
				// Check if the property has both KeyAttribute and ColumnAttribute
				if (properties.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0 && properties.GetCustomAttributes(typeof(ColumnAttribute), true).FirstOrDefault() is
					ColumnAttribute columnAttr)
				{
					return (columnAttr.Name, properties.Name);
				}
			}

			throw new Exception("Model does not contain the KeyAttribute or ColumnAttribute!");
		}

		/// <summary>
		/// Gets the table name for the given type using the TableAttribute.
		/// </summary>
		/// <typeparam name="T">The type to inspect.</typeparam>
		/// <returns>The name of the table as specified by the TableAttribute.</returns>
		/// <exception cref="Exception">Thrown if the TableAttribute is not found.</exception>
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
