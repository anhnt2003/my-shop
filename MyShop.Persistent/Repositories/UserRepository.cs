using MyShop.Domain.AggregateModels.UserAggregate.Models;
using MyShop.Domain.AggregateModels.UserAggregate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Persistent.Repositories
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        public UserRepository(MyShopDbContext dbContext) : base(dbContext)
        {
        }

        protected override Expression<Func<User, bool>> GetByIdExpression(long id)
        {
            return entity => entity.Id == id;
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext
                              .Set<User>()
                              .FirstOrDefaultAsync(e => e.Email.ToUpper() == email.ToUpper(), cancellationToken);
            return entity;
        }
    }
}
