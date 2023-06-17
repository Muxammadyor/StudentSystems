using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.EntityTypeConfiguration
{
    public sealed class SubjectOfStudentConfiguration : IEntityTypeConfiguration<SubjectsOfStudents>
    {
        public void Configure(EntityTypeBuilder<SubjectsOfStudents> builder)
        {
            builder.ToTable("SublectsOfStudents");

            builder.HasKey(sublectsOfStudents => sublectsOfStudents.Id);

            builder
                .Property(sublectsOfStudents => sublectsOfStudents.Mark);

            builder
                .HasOne(ss => ss.Student)
                .WithMany(ss => ss.SubjectOfStudent)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(ss => ss.SubjectsOfTeachers)
                .WithMany(ss => ss.SubsOfStudents);   
        }
    }
}
