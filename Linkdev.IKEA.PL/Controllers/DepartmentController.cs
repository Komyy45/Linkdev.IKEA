using Linkdev.IKEA.BLL.Models.Department;
using Linkdev.IKEA.BLL.Services.Departments;
using Linkdev.IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Linkdev.IKEA.PL.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _enviroment;

        public DepartmentController(IDepartmentService departmentService, 
									ILogger<DepartmentController> logger, 
									IWebHostEnvironment enviroment)
		{
			_departmentService = departmentService;
            _logger = logger;
            _enviroment = enviroment;
        }

		[HttpGet] // Get: "BaseUrl/Department/Index"
		public IActionResult Index()
		{
			var departments = _departmentService.GetAllDepartments();

			return View(departments);
		}

		[HttpGet] // Get: "BaseUrl/Department/Create"
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost] // Post: "BaseUrl/Department/Create"
		public IActionResult Create(CreatedDepartmentDto createdDepartment)
		{
			if (!ModelState.IsValid)
				return View(createdDepartment);

			try
			{
				if (_departmentService.CreateDepartment(createdDepartment) > 0)
					return Redirect(nameof(Index));
				else
				{
					ModelState.AddModelError(string.Empty, "Department is not Created");
					return View(createdDepartment);
				}

				
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, ex.Message);

				if (_enviroment.IsDevelopment())
				{
					ModelState.AddModelError(string.Empty, ex.Message);
					return View(createdDepartment);
				}
				else
				{
					return View("Error", "Department is not Created");
				}
					
			}
		}
	}
}
