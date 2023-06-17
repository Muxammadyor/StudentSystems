using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Contexts;

namespace StudentSystem.Infrastructure.Repository
{
    public class STRepository : GenericRepository<SubjectsOfTeachers, Guid>, ISTRepository
    {
        public STRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}

