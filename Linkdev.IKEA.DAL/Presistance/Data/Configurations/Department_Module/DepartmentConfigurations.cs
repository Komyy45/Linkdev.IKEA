using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linkdev.IKEA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linkdev.IKEA.DAL.Presistance.Data.Configurations.Department_Module
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id)
                   .UseIdentityColumn(10, 10)
                   .IsRequired();

            builder.Property(D => D.Code)
                   .HasColumnType(nameof(SqlDbType.VarChar))
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(D => D.Name)
                   .HasColumnType(nameof(SqlDbType.VarChar))
                   .HasMaxLength(50)
                   .IsRequired();

            //builder.Property(D => D.CreatedBy)
            //	   .IsRequired();

            //builder.Property(D => D.LastModifiedBy)
            //	   .IsRequired();

            builder.Property(D => D.LastModifiedOn)
                   .HasComputedColumnSql("GetDate()");

            builder.Property(D => D.CreatedOn)
                   .HasDefaultValueSql("GetDate()");

            builder.Property(D => D.CreationDate)
                   .HasDefaultValueSql("Convert(Date, GetDate())")
                   .IsRequired();
        }
    }
}
