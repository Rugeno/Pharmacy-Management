using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeroPharmaProject.Models.DTO;

namespace MeroPharmaProject.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) 
        {

        }

       

        
    }
}
