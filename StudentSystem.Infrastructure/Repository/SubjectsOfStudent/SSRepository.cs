using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Infrastructure.Repository
{
    public class SSRepository : GenericRepository<SubjectsOfStudents, Guid>, ISSRepository
    {
        public SSRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
