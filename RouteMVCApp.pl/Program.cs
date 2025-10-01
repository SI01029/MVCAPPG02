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
