using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Contexts;

namespace StudentSystem.Infrastructure.Repository;

public sealed class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
    }
}