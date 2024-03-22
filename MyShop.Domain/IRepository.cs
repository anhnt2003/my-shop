using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain
{
    public interface IRepository<TAggregate, TKey> where TAggregate: class
    {
        Task<TAggregate> AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

        Task<TAggregate> UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken= default);

        Task DeleteAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

        Task<TAggregate?> GetAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
