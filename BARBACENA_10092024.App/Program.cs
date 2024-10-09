using BARBACENA_10092024.App.Repositories;
using BARBACENA_10092024.App.Repositories.Interface;
using BARBACENA_10092024.App.Services;
using BARBACENA_10092024.App.Services.Interface;
using BARBACENA_10092024.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
}));

// Add Services
builder.Services.AddScoped<IVideoService, VideoService>();

// Add Repositories
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

// Retrieve the directory paths from appsettings
List<string> paths = new List<string>()
{
    builder.Configuration.GetSection("Directories:Videos").Value,
    builder.Configuration.GetSection("Directories:Ffmpeg").Value
};

foreach (var path in paths)
{
    // Check if directory exists and create it if not
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
