using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebBanDoThoiTrang.Models;

namespace WebBanDoThoiTrang.Data
{
    public class AppDbcontext : IdentityDbContext<Users>
    {

        public AppDbcontext(DbContextOptions<AppDbcontext> options)
            : base(options)
        {

        }

        public DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public DbSet<SanPham> SanPhams { get; set; } = null!;
        public DbSet<DonHang> DonHangs { get; set; } = null!;
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }


    }

}
