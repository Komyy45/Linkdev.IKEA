using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.BLL.Models.Department;
using Linkdev.IKEA.DAL.Entities.Department;
using Linkdev.IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore.Query;

namespace Linkdev.IKEA.BLL.Services.Departments
{
	public class DepartmentService : IDepartmentService
	{
		private readonly DepartmentRepository _departmentRepo;

		public DepartmentService(DepartmentRepository departmentRepo) // Asking CLR for object from class Implementing IDepartment Repository Interface
		{
			_departmentRepo = departmentRepo;
		}

		public IEnumerable<DepartmentDto> GetAllDepartments()
		{
			var departments = _departmentRepo.GetAllAsQueryable()
											 .Select(D => new { D.Code, D.Name, D.Description, D.CreationDate });

			foreach(var department in departments)
			{
				yield return new DepartmentDto()
				{
					Code = department.Code,
					Name = department.Name,
					Description = department.Description,
					CreationDate = department.CreationDate,
				};
			}
		}

		public DepartmentDetailsDto? GetDepartmentDetails(int id)
		{
			var department = _departmentRepo.Get(id);

			if(department is { })
			return new DepartmentDetailsDto()
			{
				Id = department.Id,
				Code = department.Code,
				Name = department.Name,
				Description = department.Description,
				CreationDate = department.CreationDate,
				CreatedBy = department.CreatedBy,
				LastModifiedBy = department.LastModifiedBy,
				LastModifiedOn = DateTime.UtcNow
			};

			return null;
		}

		public int CreateDepartment(CreatedDepartmentDto model)
		{
			var department = new Department()
			{
				Code = model.Code,
				Name = model.Name,
				Description = model.Description,
				CreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
				CreatedBy = 1,
				LastModifiedBy = 1,
				LastModifiedOn = DateTime.UtcNow,
				CreatedOn = DateTime.UtcNow,
			};

			return _departmentRepo.Add(department);
		}

		public int UpdateDepartment(UpdatedDepartmentDto model)
		{
			var department = new Department()
			{
				Id = model.Id,
				Code = model.Code,
				Name = model.Name,
				Description = model.Description,
			};

			return _departmentRepo.Update(department);	
		}

		public bool DeleteDepartment(int departmentId)
			=> _departmentRepo.Delete(departmentId) > 0;

	}
}
