using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.EntityTypeConfiguration
{
    public sealed class SubjectOfTeacherConfiguration : IEntityTypeConfiguration<SubjectsOfTeachers>
    {
        public void Configure(EntityTypeBuilder<SubjectsOfTeachers> builder)
        {
            builder.ToTable("SubjectsOfTeachers");

            builder.HasKey(st => st.Id);

            builder
                .HasOne(st => st.Subject)
                .WithMany(st => st.SubjectsOfTeachers);

            builder
                .HasOne(st => st.Teacher)
                .WithMany(st => st.SubjectsOfTeachers);

            builder
                .HasMany(st => st.SubsOfStudents)
                .WithOne(st => st.SubjectsOfTeachers);
        }
    }
}
