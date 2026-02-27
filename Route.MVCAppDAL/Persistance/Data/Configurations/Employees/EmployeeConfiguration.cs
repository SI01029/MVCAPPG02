using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.MVCApp.DAL.Models.Common;
using Route.MVCApp.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Data.Configurations.Employees
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(D => D.CreatedOn).HasComputedColumnSql("GETUTCDATE");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GETDATE");

            builder.Property(E => E.Gender).HasConversion(
                (gender) => gender.ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                );

            builder.Property(E => E.EmployeeType).HasConversion(
                (type) => type.ToString(),
                (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type)
                );
        }
    }
}
