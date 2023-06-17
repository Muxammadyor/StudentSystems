using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Domain.Entities;
using StudentSystem.Domain.Enums;
using StudentSystem.Domain.Entities;
using StudentSystem.Domain.Enums;

namespace StudentSystem.Infrastructure.EntityTypeConfigurations;


public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.FirstName)
            .HasMaxLength(100)
            .IsRequired(true);
        builder
            .Property(user => user.LastName)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .Property(user => user.Email)
            .HasMaxLength(255)
            .IsRequired(true);

        builder
            .Property(user => user.PasswordHash)
            .HasMaxLength(256)
            .IsRequired(true);

        builder
            .Property(user => user.Salt)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .HasMany(user => user.SubjectsOfTeachers)
            .WithOne(user => user.Teacher)
            .HasForeignKey(user => user.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(user => user.SubjectOfStudent) 
            .WithOne(user => user.Student)
            .HasForeignKey(user => user.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(GenerateUsers());
    }

    private List<User> GenerateUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = Guid.Parse("583f9a8a-6bbb-4a47-3a04-08db37684f69"),
                FirstName="Admin",
                LastName="Admin",
                PhoneNumber="+998942142336",
                Role = UserRole.Admin,
                Email="muxammadyor@gmail.com",
                PasswordHash = "U3wZq33dK4rvlNqhJ0zTQlQ4jfvA5brrTfmdid+yDtk=",
                Salt = "15d9bb01-0aa2-4b35-b25b-362287751b03",
            }
        };
    }
}
