using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Contexts;

namespace StudentSystem.Infrastructure.Repository.Subjects
{
    public sealed class SubjectRepository : GenericRepository<Subject, Guid>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
