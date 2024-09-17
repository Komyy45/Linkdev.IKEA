using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.IKEA.BLL.Models.Department
{
	public class DepartmentDto
	{
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
