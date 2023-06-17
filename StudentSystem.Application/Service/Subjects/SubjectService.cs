using StudentSystem.Application.DTO.Subject;
using StudentSystem.Infrastructure.Repository.Subjects;

namespace StudentSystem.Application.Service.Subjects
{
    public partial class SubjectService : ISubjectService
    {
        private readonly ISubjectFactory subjectFactory;
        private readonly ISubjectRepository subjectRepository;

        public SubjectService(
            ISubjectRepository subjectRepository,
            ISubjectFactory subjectFactory)
        {
            this.subjectRepository = subjectRepository;
            this.subjectFactory = subjectFactory;
        }

        public async ValueTask<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subjectForCreationDto)
        {
            ValidateSubjectForCreationDto(subjectForCreationDto);

            var newSubject = this.subjectFactory
                .MapToSubject(subjectForCreationDto);

            var addSubject = await subjectRepository.InsertAsync(newSubject);

            return subjectFactory.MapToSubjectDto(addSubject);
        }

        public async ValueTask<SubjectDto> RetriveByIdAsync(Guid subjectId)
        {
            var subject = await this.subjectRepository.SelectByIdAsync(subjectId);

            return this.subjectFactory.MapToSubjectDto(subject);
        }

        public IQueryable<SubjectDto> RetriveSubjects()
        {
            var subjects = this.subjectRepository.SelectAll();

            return subjects.Select(subject => 
            this.subjectFactory.MapToSubjectDto(subject));
        }
    }
}
