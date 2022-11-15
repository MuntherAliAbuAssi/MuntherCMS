
using Microsoft.EntityFrameworkCore;
using MuntherCMS.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using MuntherCMS.Infrastructure.Mapper;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

var autMapper = new MapperConfiguration(item =>item.AddProfile(new Mapping()));
IMapper mapper = autMapper.CreateMapper();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CMSDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   // app.UseExceptionHandler("/Home/Error");
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
