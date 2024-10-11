
using ApiGap.Repository;
using Microsoft.EntityFrameworkCore;
using ApiGap.Data;
using ApiGap.Repository.Interfaces;
using ApiGap.Services;
using ApiGap.Services.Interfaces;


namespace ApiGap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var connectionString = builder.Configuration.GetConnectionString("Database");

            builder.Services.AddEntityFrameworkMySql().AddDbContext<ApiGapDBContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 31))));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

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
