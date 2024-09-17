using Linkdev.IKEA.BLL.Services.Departments;
using Linkdev.IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Linkdev.IKEA.PL.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		public IActionResult Index()
		{
			var departments = _departmentService.GetAllDepartments();

			return View(departments);
		}
	}
}
