using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.Repository
{
    public interface ISSRepository : IGenericRepository<SubjectsOfStudents, Guid>
    {
    }
}
