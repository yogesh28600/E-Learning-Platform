using CourseService.Context;
using CourseService.Repositories.CoursesRepo;
using CourseService.Repositories.ModulesRepo;
using Microsoft.EntityFrameworkCore;

namespace CourseService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CourseContext>(options=>
            options.UseSqlite(builder.Configuration.GetConnectionString("CourseDb")));
            builder.Services.AddScoped<ICourseRepo, CoursesRepo>();
            builder.Services.AddScoped<IModulesRepo, ModulesRepo>();
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
