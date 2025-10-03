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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Apply All Configuration classes
        }

        public DbSet<Department> Departments { get; set; }
    }
}
