using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.DAL.Entities.Department;

namespace Linkdev.IKEA.DAL.Presistance.Repositories.Departments
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetAll(bool AsNoTracking = true);

		IQueryable<Department> GetAllAsQueryable();

		Department? Get(int? id);
		
		int Add(Department department);

		int Update(Department department);
		
		int Delete(int id);
	}
}
