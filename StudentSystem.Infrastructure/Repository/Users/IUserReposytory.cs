using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.Repository;

public interface IUserRepository : IGenericRepository<User, Guid>
{
}