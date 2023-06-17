namespace StudentSystem.Domain.Entities
{
    public class SubjectsOfTeachers
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }
        public User Teacher { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public IList<SubjectsOfStudents> SubsOfStudents { get; set; }

    }
}
