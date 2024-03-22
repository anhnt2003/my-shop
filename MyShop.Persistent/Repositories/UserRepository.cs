using MyShop.Domain.AggregateModels.UserAggregate.Models;
using MyShop.Domain.AggregateModels.UserAggregate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
