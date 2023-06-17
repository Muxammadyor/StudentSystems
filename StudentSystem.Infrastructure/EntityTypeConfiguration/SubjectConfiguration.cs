using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.EntityTypeConfiguration
{
    public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(subject => subject.Id);

            builder
                .Property(subject => subject.SubjectName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder
                .HasMany(subject => subject.SubjectsOfTeachers)
                .WithOne(subject => subject.Subject)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
