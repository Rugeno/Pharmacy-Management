using MeroPharma.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MeroPharma.Data
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
