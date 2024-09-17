using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.DAL.Entities.Department;
using Linkdev.IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace Linkdev.IKEA.DAL.Presistance.Repositories.Departments
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;

		public DepartmentRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Department> GetAll(bool AsNoTracking = true)
		{
			if (AsNoTracking)
				return _context.Departments.AsNoTracking().ToList();

			return  _context.Departments.ToList();
		}

		public IQueryable<Department> GetAllAsQueryable()
		{
			return _context.Departments;
		}

		public Department? Get(int id)
		{
			return _context.Departments.Find(id);
		}

		public int Add(Department department)
		{
			_context.Departments.Add(department);
			return _context.SaveChanges();
		}

		public int Update(Department department)
		{
			_context.Departments.Add(department);
			return _context.SaveChanges();
		}

		public int Delete(int id)
		{
			var department = Get(id);

			if (department is { })
			_context.Remove(department);

			return _context.SaveChanges();
		}
	}

}
