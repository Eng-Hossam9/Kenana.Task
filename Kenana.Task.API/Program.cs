
using EXamination.Core.Data;
using EXamination.Core.RepositoriesInterFaces;
using EXamination.Core.ServicesInterFaces;
using EXamination.Repository.AdminEmail;
using EXamination.Repository.Contexts;
using EXamination.Repository.Repositories;
using EXamination.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Kenana.Task.API
{
    public class Program
    {
        public static  async System.Threading.Tasks.Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ExaminationContext>(option=>
                                                            option.UseSqlServer(
                                                                builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddDbContext<AppUsreDb>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppUsreDb>()
        .AddDefaultTokenProviders();

            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IStudentExamRepository, StudentExamRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentExamService, StudentExamService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

            try
            {

                await EmailAdmin.SeedAdmin(userManager);
            }
            catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Problem in Migrations");
            }



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
