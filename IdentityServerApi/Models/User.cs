using Microsoft.AspNetCore.Identity;

namespace IdentityServerApi.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
