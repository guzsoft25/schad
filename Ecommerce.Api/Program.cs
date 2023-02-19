using Ecommerce.Business.Custom;
using Ecommerce.Business.Services;
using Ecommerce.Data.Contexts;
using Ecommerce.Data.Repositories;
using Ecommerce.Shared.Contracts;
using NLog;
using NLog.Web;

namespace Ecommerce.Api
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
                builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);

                builder.Logging.ClearProviders();
                builder.Host.UseNLog(); 

                builder.Services.AddTransient<ICustomLogger, CustomLogger>();
                builder.Services.AddTransient<ICustomSettings, CustomSettings>();
                builder.Services.AddTransient<ICustomEnvironment, CustomEnvironment>();

                builder.Services.AddDbContext<EcommerceDbContext>();
                builder.Services.AddTransient<IProductRepository, ProductRepository>();
                builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
                builder.Services.AddTransient<ICustomerTypeRepository, CustomerTypeRepository>();
                builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();

                builder.Services.AddTransient<IProductFakerServices, ProductFakerServices>();
                builder.Services.AddTransient<IProductServices, ProductServices>();
                builder.Services.AddTransient<ICustomerServices, CustomerServices>();
                builder.Services.AddTransient<ICustomerTypeServices, CustomerTypeServices>();
                builder.Services.AddTransient<IInvoiceServices, InvoiceServices>();

                builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddHttpClient();

                //Get environment

                bool isDevelopment = builder.Configuration.GetValue<bool>("Settings:isDevelopment");
                NLog.LogManager.Configuration.Variables["myenv"] = isDevelopment ? "TEST" : "PROD";

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
			catch (Exception ex) {
                logger.Fatal(ex);
				throw;
			}
        }
    }
}