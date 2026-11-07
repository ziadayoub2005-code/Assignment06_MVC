namespace MVCGiza02
{
    public class Program
    {
        // Main Point / etry Point :
        // CLR sgtart app from here .. 
        // Console app : Main { // CLR }
        // Mvc web app : Main : build web app ..
        // builder design pattern .. self
        public static void Main(string[] args)
        {
            // 1- Build we app with some configs ..
            var builder = WebApplication.CreateBuilder(args);

            // DbContext (Unmanaged resource)
            // Life time as a service : Design Pattern 
            // Dependency Injection
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();


            // 2- Handle req - build res : 
            // Configure the HTTP request pipeline.

            // development -> Exception Page ..
            #region httpReq Pipeline
            if (!app.Environment.IsDevelopment())
            {
                // friendly 
                // funny - ..
                app.UseExceptionHandler("/Home/Error");
            }
            // serve static files (wwwroot)
            app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
            #endregion

            app.Run();
        }
    }
}
