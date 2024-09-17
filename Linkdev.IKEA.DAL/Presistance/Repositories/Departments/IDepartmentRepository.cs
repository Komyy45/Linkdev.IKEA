using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.DAL.Models.Department;

namespace Linkdev.IKEA.DAL.Presistance.Repositories.Departments
{
	internal interface IDepartmentRepository
	{
		IEnumerable<Department> GetAll(bool AsNoTracking = true);
		
		Department? Get(int id);
		
		int Add(Department department);

		int Update(Department department);
		
		int Delete(int id);
	}
}
