
using EnrollmentService.Context;
using EnrollmentService.Repositories.EnrollmentRepo;
using EnrollmentService.Repositories.ProgressRepo;
using EnrollmentService.Repositories.ReviewRepo;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentService
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
            builder.Services.AddDbContext<EnrollmentDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("EnrollmentDb")));
            builder.Services.AddScoped<IEnrollmentRepo, EnrollmentRepo>();
            builder.Services.AddScoped<IProgressRepo, ProgressRepo>();
            builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
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
            app.UseCors("AllowSpecificOrigins");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
