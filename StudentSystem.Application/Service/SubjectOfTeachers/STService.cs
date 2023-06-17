using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Repository;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public partial class STService : ISTService
    {
        private readonly ISTRepository sTRepository;
        private readonly ISTFactory sTFactory;

        public STService(
            ISTRepository sTRepository,
            ISTFactory sTFactory)
        {
            this.sTRepository = sTRepository;
            this.sTFactory = sTFactory;
        }

        public ValueTask<SubjectsOfTeachers> CreationAsync(STCreationDto sTCreationDto)
        {
            var newSt = sTFactory.MapToST(sTCreationDto);

            var addST = sTRepository.InsertAsync(newSt);

            return addST;
        }

        public  IQueryable<STDto> RetriveBySubjectIdWhithDeteils(Guid subjectId)
        {
            var storegeSt =  this.sTRepository
                .SelectAll(st => st.SubjectId==subjectId,
                    includes: new string[] {nameof(SubjectsOfTeachers.Teacher) });

            return storegeSt.Select(st=> this.sTFactory.MapToSTDto(st));
        }

        public IQueryable<STDto> RetriveByTeacherIdWhithDeteils(Guid teacherId)
        {
            var storegeSt = this.sTRepository
                .SelectAll(st => st.TeacherId == teacherId,
                 includes: new string[] { nameof(SubjectsOfTeachers.Subject) });

            return storegeSt.Select(st => this.sTFactory.MapToSTDto(st));
        }
    }
}
