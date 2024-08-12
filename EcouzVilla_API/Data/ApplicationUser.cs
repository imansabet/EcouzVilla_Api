using Microsoft.AspNetCore.Identity;

namespace EcouzVilla_API.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
