using Sample.Domain;
using Sample.Domain.Persistence.Contracts;

namespace Sample.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


    }
}

