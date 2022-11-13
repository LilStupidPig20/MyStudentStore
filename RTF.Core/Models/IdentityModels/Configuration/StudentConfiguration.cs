using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RTF.Core.Models.IdentityModels.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasData(
            new Student
            {
                Id = 1,
                FirstName = "Тест",
                LastName = "Тестовыч",
                Group = "РИ-000000"
            }
        );
    }
}