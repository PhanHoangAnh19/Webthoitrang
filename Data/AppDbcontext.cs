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



    }

}
