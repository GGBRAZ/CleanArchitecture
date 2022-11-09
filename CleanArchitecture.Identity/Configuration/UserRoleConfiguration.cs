using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "e6fb7f8b-3ba6-427c-98fd-9798527524ae",
                    UserId = "fd9239c4-9036-4d40-b35f-1e762facfc1e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1eb9312e-973f-4e81-bc92-47b864c93f24",
                    UserId = "c6c041e3-1f65-4f36-afac-05753e47e847"
                }

            );
        }
    }
}
