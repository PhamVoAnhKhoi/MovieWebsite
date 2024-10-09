using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MovieWebsite.Data;
using Microsoft.EntityFrameworkCore;
using MovieWebsite.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add DbContext and IMovieReference services
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieWebsite")));

// Thêm dịch vụ Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<MovieDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<SignInManager<User>>();
builder.Services.AddScoped<UserManager<User>>();

// Đăng ký các repository
builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
builder.Services.AddScoped<IGenreRepository, EFGenreRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<ICountryRepository, EFCountryRepository>();

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

app.UseAuthentication(); // Thêm dòng này để sử dụng xác thực
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

// Khởi tạo dữ liệu mẫu (nếu cần thiết)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<Role>>();

    // Tạo vai trò Customer nếu chưa tồn tại
    var roleExists = await roleManager.RoleExistsAsync("Customer");
    if (!roleExists)
    {
        await roleManager.CreateAsync(new Role { Name = "Customer" });
    }

    // Bạn có thể thêm các vai trò khác ở đây
}
