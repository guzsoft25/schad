using Ecommerce.Business.Custom;
using Ecommerce.Shared.Contracts;
using NLog;
using NLog.Web;

namespace Ecommerce.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            //logger.Debug("Init Main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews().AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = null);

                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                builder.Services.AddTransient<ICustomLogger, CustomLogger>();
                builder.Services.AddTransient<ICustomSettings, CustomSettings>();
                builder.Services.AddTransient<ICustomEnvironment, CustomEnvironment>();


                bool isDevelopment = builder.Configuration.GetValue<bool>("Settings:isDevelopment");
                NLog.LogManager.Configuration.Variables["myenv"] = isDevelopment ? "TEST" : "PROD";


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment()) {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}