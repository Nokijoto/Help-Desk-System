using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gateway
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = 127.0.0.1; Database = Gateway; user id = SA; password = Pass@word; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;");
            //optionsBuilder.UseSqlServer("Server=DESKTOP-OO8S81V;Database=Gateway;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
