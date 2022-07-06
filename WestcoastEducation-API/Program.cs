using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WestcoastEducation_API.Data;
using WestcoastEducation_API.Helpers;
using WestcoastEducation_API.Interfaces;
using WestcoastEducation_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CourseContext>(Options=> {
    Options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));

});
//Authontication 
builder.Services.AddIdentity<IdentityUser, IdentityRole>(option =>
{
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredLength = 8;

    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
}).AddEntityFrameworkStores<CourseContext>();

//Dependency injection for Interfaces and Classes
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

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
app.UseAuthentication();
// app.UseAuthorization();

 app.MapControllers();

using var scope=app.Services.CreateScope();
var services=scope.ServiceProvider;
try
{
    var context =services.GetRequiredService<CourseContext>();
    await context.Database.MigrateAsync();
    await LoadData.LoadCategories(context);
    await LoadData.LoadCourses(context);
    await LoadData.LoadStudents(context);
    await LoadData.LoadTeachers(context);
}
catch (Exception  ex)
{
    
  var logger =services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "Ett fel inträffade när migrering utfördes!");
}

 await app.RunAsync();
