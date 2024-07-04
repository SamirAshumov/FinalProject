using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExamSystem.Core.Models;
using ExamSystem.Data.DAL;
using ExamSystem.Business.Services.Abstracts;
using ExamSystem.Business.Services.Concretes;
using ExamSystem.Core.RepositoryAbstracts;
using ExamSystem.Data.RepositoryConcretes;

namespace Final_Exam_System
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Database context
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

			// Identity
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultUI()
				.AddDefaultTokenProviders();

			

			// Service and Repository registrations
			builder.Services.AddScoped<IExamService, ExamService>();
			builder.Services.AddScoped<IQuestionService, QuestionService>();
			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<IDashboardService, DashboardService>();
			builder.Services.AddScoped<IExamRepo, ExamRepo>();
			builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
			builder.Services.AddScoped<IStudentRepo, StudentRepo>();
			builder.Services.AddScoped<IDashboardRepo, DashboardRepo>();

			var app = builder.Build();

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

			app.UseAuthentication();
			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.MapRazorPages();

			app.Run();
		}
	}
}