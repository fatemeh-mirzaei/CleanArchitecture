using Sample.Application.Persistence.Contracts;
using Sample.Domain;

namespace Sample.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


    }
}

