using Microsoft.EntityFrameworkCore;
using Route.MVCApp.DAL.Models.Dpartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Route.MVCApp.DAL.Persistance.Data.Contixts
{
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.;Database =MVCAPPG02; Trusted_Connection=true;TrustSeverCertificate =true");
              
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Apply All Configuration classes
        }

        public DbSet<Department> Departments { get; set; }
    }
}
