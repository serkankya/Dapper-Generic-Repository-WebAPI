using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Business.Abstract
{
	public interface IGenericRepository<T> where T : class, new()
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<bool> InsertAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(int id);
		Task<T> GetByIdAsync(int id);
	}
}
