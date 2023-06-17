namespace StudentSystem.Domain.Entities
{
    public class SubjectsOfStudents
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public User Student { get; set; }

        public Guid SubjectsOfTeachersId { get; set; }
        public SubjectsOfTeachers SubjectsOfTeachers { get; set; }

        public int Mark { get; set; }

    }
}
