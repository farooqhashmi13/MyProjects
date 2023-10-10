using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.DataAccess;
using PkHiveLibrary.Interfaces;
using PkHiveLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IJobsData, JobsData>();
builder.Services.AddTransient<IContactData, ContactData>();
builder.Services.AddTransient<IExamsData, ExamsData>();
builder.Services.AddTransient<ISubjectsData, SubjectsData>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
