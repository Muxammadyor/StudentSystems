using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.Repository
{
    public interface ISTRepository : IGenericRepository<SubjectsOfTeachers, Guid>
    {
    }
}
