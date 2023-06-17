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

        public async ValueTask<SubjectsOfStudents> CreationSS(SSCreationDto sSCreationDto)
        {
            var newSS = this.sSFactory.MapToSS(sSCreationDto);

            var addSS = await this.sSRepository.InsertAsync(newSS);

            return addSS;
            
        }

        public ValueTask<SubjectsOfStudents> ModifySSAsync(SSForModificationDto sSForModificationDto)
        {
            
        }

        public IQueryable<SSDto> RetriveBySTId(Guid stId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SSDto> RetriveByStudentId(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SSDto> RetriveBySubjectId(Guid subjectId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SSDto> RetriveByTeacherId(Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
