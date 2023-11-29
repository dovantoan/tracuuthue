using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class thuVienPhapLuatDBContextFactory: IDesignTimeDbContextFactory<thuVienPhapLuatDBContext>
    {
        public thuVienPhapLuatDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<thuVienPhapLuatDBContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            return new thuVienPhapLuatDBContext(optionsBuilder.Options);
        }
    }
}
