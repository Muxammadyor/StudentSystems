namespace StudentSystem.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }     
        public string SubjectName { get; set; }
        
        public IList<SubjectsOfTeachers> SubjectsOfTeachers { get; set;}
    }
}
