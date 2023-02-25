using Microsoft.AspNetCore.Identity;

namespace MeroPharmaProject.Models.Domain
{
    public class AppUser : IdentityUser
    {
        

        public string Name { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
