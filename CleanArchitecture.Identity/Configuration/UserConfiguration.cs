using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "fd9239c4-9036-4d40-b35f-1e762facfc1e",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Name = "zarbg",
                    Nickname = "zarbg",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "Zarbg2025$"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "c6c041e3-1f65-4f36-afac-05753e47e847",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Name = "Juan",
                    Nickname = "Perez",
                    UserName = "juanperez@localhost.com",
                    NormalizedUserName = "juanperez@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "Zarbg2025$"),
                    EmailConfirmed = true,
                }

            );
        }
    }
}
