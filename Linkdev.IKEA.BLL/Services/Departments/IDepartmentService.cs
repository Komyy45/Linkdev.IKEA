using Linkdev.IKEA.BLL.Models.Department;

namespace Linkdev.IKEA.BLL.Services.Departments
{
	public interface IDepartmentService
	{
		IEnumerable<DepartmentDto> GetAllDepartments();

		DepartmentDetailsDto? GetDepartmentDetails(int? id);

		int CreateDepartment(CreatedDepartmentDto model);
		
		int UpdateDepartment(UpdatedDepartmentDto model);

		bool DeleteDepartment(int departmentId);
	}
}
