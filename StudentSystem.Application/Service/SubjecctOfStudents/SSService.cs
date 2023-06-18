using StudentSystem.Application.DTO;
using StudentSystem.Application.DTO.SubjectsOfStudents;
using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Repository;

namespace StudentSystem.Application.Service
{
    public class SSService : ISSService
    {
        private readonly ISSFactory sSFactory;
        private readonly ISSRepository sSRepository;

        public SSService(ISSRepository sSRepository,
                        ISSFactory sSFactory)
        {
            this.sSRepository = sSRepository;
            this.sSFactory = sSFactory;
        }

        public async ValueTask<SubjectsOfStudents> CreationSSAsync(SSCreationDto sSCreationDto)
        {
            var newSS = this.sSFactory.MapToSS(sSCreationDto);

            var addSS = await this.sSRepository.InsertAsync(newSS);

            return addSS;
            
        }

        public async ValueTask<SubjectsOfStudents> ModifySSAsync(SSForModificationDto sSForModificationDto)
        {
            var storageSS = await this.sSRepository
            .SelectByIdAsync(sSForModificationDto.id);

            sSFactory.MaptoSS(storageSS, sSForModificationDto);

            return await this.sSRepository.UpdateAsync(storageSS);
        }

        public IQueryable<SSDto> RetriveByMark(int mark)
        {
            var storegeSt = this.sSRepository
               .SelectAll(st => st.Mark >= mark,
                   includes: new string[] { nameof(SubjectsOfStudents.Student) });

            return storegeSt.Select(st => this.sSFactory.MapToSSDto(st));
        }

        public IQueryable<SSDto> RetriveBySTId(Guid stId)
        {
            var storegeSt = this.sSRepository
                .SelectAll(st => st.SubjectsOfTeachersId == stId,
                    includes: new string[] { nameof(SubjectsOfStudents.Student) });

            return storegeSt.Select(st => this.sSFactory.MapToSSDto(st));
        }

        public IQueryable<SSDto> RetriveByStudentId(Guid studentId)
        {
            var storegeSt = this.sSRepository
                 .SelectAll(st => st.StudentId == studentId,
                     includes: new string[] { nameof(SubjectsOfStudents.SubjectsOfTeachers) });

            return storegeSt.Select(st => this.sSFactory.MapToSSDto(st));
        }

        public IQueryable<SSDto> RetriveBySubjectId(Guid subjectId)
        {
            var storegeSt = this.sSRepository
                .SelectAll(st => st.SubjectsOfTeachers.SubjectId == subjectId,
                    includes: new string[] { nameof(SubjectsOfStudents.Student) });

            return storegeSt.Select(st => this.sSFactory.MapToSSDto(st));
        }

        public IQueryable<SSDto> RetriveByTeacherId(Guid teacherId)
        {
            var storegeSt = this.sSRepository
                .SelectAll(st => st.SubjectsOfTeachers.TeacherId == teacherId,
                    includes: new string[] { nameof(SubjectsOfStudents.Student) });

            return storegeSt.Select(st => this.sSFactory.MapToSSDto(st));
        }
    }
}
