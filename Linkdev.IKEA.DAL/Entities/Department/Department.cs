﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkdev.IKEA.DAL.Entities.Department
{
	public class Department : ModelBase
	{
		public string Code { get; set; } = null!;

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

        public DateOnly CreationDate { get; set; }
    }
}
