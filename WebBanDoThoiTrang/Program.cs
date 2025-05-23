using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebBanDoThoiTrang.Data;
using WebBanDoThoiTrang.Models;
using WebBanDoThoiTrang.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) Đăng ký các service
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<Users, IdentityRole>(opts =>
{
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequiredLength = 8;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireLowercase = false;
    opts.User.RequireUniqueEmail = true;
    opts.SignIn.RequireConfirmedAccount = false;
    opts.SignIn.RequireConfirmedEmail = false;
    opts.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<AppDbcontext>()
.AddDefaultTokenProviders();

// Session + CartService
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromHours(1);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICartService, SessionCartService>();

var app = builder.Build();

// 2) Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();   // show stacktrace
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SanPham}/{action=DanhSachSanPham}/{id?}"
);

app.Run();
