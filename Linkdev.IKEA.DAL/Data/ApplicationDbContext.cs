using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Linkdev.IKEA.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext():base()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Server = .; Database=MvcApplication; Trusted_connection = true; TrustServerCertificate = true;")
	}
}
