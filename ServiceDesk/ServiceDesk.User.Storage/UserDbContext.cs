using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceDesk.User.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesk.User.Storage
{
    public class UserDbContext : IdentityDbContext<Storage.Entities.User, Role, Guid>
    {
        private readonly IConfiguration _configuration;

        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = 127.0.0.1; Database = UserDb; user id = SA; password = Pass@word; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var customerRoleId = Guid.NewGuid();
            var serviceManRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();

            builder.Entity<Role>().HasData(
                new Role { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" },
                new Role { Id = serviceManRoleId, Name = "ServiceMan", NormalizedName = "SERVICEMAN" },
                new Role { Id = adminRoleId, Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            // Seed users
            var hasher = new PasswordHasher<User.Storage.Entities.User>();
            var customerId = Guid.NewGuid();
            var serviceManId = Guid.NewGuid();
            var adminId = Guid.NewGuid();

            builder.Entity<User.Storage.Entities.User>().HasData(
                new User.Storage.Entities.User
                {
                    Id = customerId,
                    UserName = "customer@example.com",
                    NormalizedUserName = "CUSTOMER@EXAMPLE.COM",
                    Email = "customer@example.com",
                    NormalizedEmail = "CUSTOMER@EXAMPLE.COM",
                    Name = "Customer",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Customer123!"),
                    SecurityStamp = string.Empty,
                    IsActive = true
                },
                new User.Storage.Entities.User
                {
                    Id = serviceManId,
                    UserName = "serviceman@example.com",
                    NormalizedUserName = "SERVICEMAN@EXAMPLE.COM",
                    Email = "serviceman@example.com",
                    NormalizedEmail = "SERVICEMAN@EXAMPLE.COM",
                    Name = "ServiceMan",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "ServiceMan123!"),
                    SecurityStamp = string.Empty,
                    IsActive = true
                },
                new User.Storage.Entities.User
                {
                    Id = adminId,
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    Name = "Administrator",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = string.Empty,
                    IsActive = true
                }
            );

            // Assign roles to users
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = customerRoleId, UserId = customerId },
                new IdentityUserRole<Guid> { RoleId = serviceManRoleId, UserId = serviceManId },
                new IdentityUserRole<Guid> { RoleId = adminRoleId, UserId = adminId }
            );
        }
    }
}
