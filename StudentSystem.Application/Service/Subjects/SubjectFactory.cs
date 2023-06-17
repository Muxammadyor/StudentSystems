using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.Subjects
{
    public class SubjectFactory : ISubjectFactory
    {
        public Subject MapToSubject(SubjectForCreationDto subjectForCreationDto)
        {
            return new Subject
            {
                SubjectName = subjectForCreationDto.name
            };
        }

        public SubjectDto MapToSubjectDto(Subject subject)
        {
            return new SubjectDto(
                subject.Id,
                subject.SubjectName);
        }
    }
}
