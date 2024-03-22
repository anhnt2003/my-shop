using Microsoft.EntityFrameworkCore;
using MyShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistent.Repositories
{
    public abstract class BaseRepository<TAggregate, TKey> : IRepository<TAggregate, TKey> where TAggregate : class
    {
        protected readonly MyShopDbContext _dbContext;
        public BaseRepository(MyShopDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected abstract Expression<Func<TAggregate, bool>> GetByIdExpression(TKey id);
        public async Task<TAggregate> AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TAggregate>().AddAsync(aggregate, cancellationToken);
            return aggregate;
        }

        public Task DeleteAsync(TAggregate aggregate, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TAggregate>().Remove(aggregate);
            return Task.CompletedTask;
        }

        public async Task<TAggregate?> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TAggregate>().FirstOrDefaultAsync(GetByIdExpression(id), cancellationToken);
            return entity;
        }

        public Task<TAggregate> UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TAggregate>().Update(aggregate);
            return Task.FromResult(aggregate);
        }
    }
}
