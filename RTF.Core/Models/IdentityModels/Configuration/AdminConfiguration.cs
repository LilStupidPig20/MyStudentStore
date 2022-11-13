using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RTF.Core.Models.IdentityModels.Configuration;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasData(
            new Admin
            {
                Id = 1,
                FirstName = "Тест",
                LastName = "Тестовыч",
                SuperRules = true
            }
        );
    }
}