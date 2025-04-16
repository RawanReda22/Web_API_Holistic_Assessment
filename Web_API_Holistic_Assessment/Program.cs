
using Microsoft.EntityFrameworkCore;
using Web_API_Holistic_Assessment.Repo.CustomerRepo;
using Web_API_Holistic_Assessment.Repo.OrderRepo;
using Web_API_Holistic_Assessment.Repo.ProductRepo;

namespace Web_API_Holistic_Assessment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(x=> 
            x.UseSqlServer(builder.Configuration.GetConnectionString("MYConnection")));
            // Add services to the container.

            builder.Services.AddScoped<ICutomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
    }
}
