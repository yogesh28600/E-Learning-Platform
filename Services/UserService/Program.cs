
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Repositories.UsersRepo;

namespace UserService
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
            builder.Services.AddDbContext<UserContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("UsersDb")));
            builder.Services.AddScoped<IUsersRepo, UsersRepo>();
            // Add CORS services to the container
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
                // Enable CORS
            app.UseCors("AllowSpecificOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
