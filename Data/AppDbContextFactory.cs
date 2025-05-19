using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using WebBanDoThoiTrang.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbcontext>
{
    public AppDbcontext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbcontext>();
        builder.UseSqlServer("Server=DESKTOP-CIC0GLM\\MSSQLSERVER01;" +
                             "Initial Catalog=WebBanDoThoiTrangDb;" +          
                             "Trusted_Connection=True;" +
                             "TrustServerCertificate=True;"+
                             "MultipleActiveResultSets=true");
        return new AppDbcontext(builder.Options);
    }
}
