using IdentityServerApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServerApi.Context
{
    public class IdentityServerContext : IdentityDbContext
    {
        public IdentityServerContext(DbContextOptions<IdentityServerContext> options)
            : base(options)
        {

        }
        public virtual DbSet<User> User { get; set; }
    }
}
