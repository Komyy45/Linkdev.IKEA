using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.IKEA.BLL.Models.Department
{
	public class CreatedDepartmentDto
	{
		[Required(ErrorMessage = "Code Is Required!, Please fill it before Submiting")]
		public string Code { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string? Description { get; set; } = null!;

		public DateOnly CreationDate { get; set; }
	}
}
