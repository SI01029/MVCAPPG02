using Microsoft.EntityFrameworkCore;
using Route.MVCApp.DAL.Persistance.Data.Contixts;

namespace RouteMVCApp.pl
{
    public class Program
    {
        //Entry point
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Configure Services [Add Service To DI Continer]

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>((ServiceProvider)=>
            //{
            //    var optionsBuildr = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionsBuildr.UseSqlServer("Server =.;Database =MVCAPPG02; Trusted_Connection=true;TrustSeverCertificate =true");
            //    var options = optionsBuildr.Options;
            //    return options;
            //});
            builder.Services.AddDbContext<ApplicationDbContext>(
                //contextLifetime: ServiceLifetime.Scoped,
                //optionsLifetime: ServiceLifetime.Scoped  //Default Value
                optionsAction: (optionBuilder) =>
                {
                     //optionBuilder.UseSqlServer(builder.Configuration.GetSection("ConnectionString")["DefaultConnection"]);
                    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
                }
                );
                
            #endregion

            var app = builder.Build();

            #region Configure K estral MiddleWares [Piplines
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

        

            //verp: BaseUrl/Controller/action
            app.MapControllerRoute(
                name: "default", 
            
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
