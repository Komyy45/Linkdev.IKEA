using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;

namespace Linkdev.IKEA.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext():base()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Server = .; Database=MvcApplication; Trusted_connection = true; TrustServerCertificate = true;");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Department> Departments { get; set; }

	}
}
