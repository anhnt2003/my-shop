using MyShop.Domain.AggregateModels.UserAggregate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.AggregateModels.UserAggregate.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
