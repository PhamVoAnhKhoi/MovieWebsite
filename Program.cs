using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MovieWebsite.Data;
using Microsoft.EntityFrameworkCore;
using MovieWebsite.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add DbContext and IMovieReference services
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieWebsite")));

// Đăng ký các repository
builder.Services.AddScoped<IMovieReference, EFMovieReference>();
builder.Services.AddScoped<IGenreReference, EFGenreReference>();
builder.Services.AddScoped<ICategoryReference, EFCategoryReference>();
builder.Services.AddScoped<ICountryReference, EFCountryReference>();
builder.Services.AddScoped<IUserReference, EFUserReference>();

// Thêm các dịch vụ khác (Controllers, Razor Pages, v.v.)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
