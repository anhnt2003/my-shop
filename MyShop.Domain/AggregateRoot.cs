using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain
{
    public class AggregateRoot<TIdType> : Entity<TIdType>, IAggregateRoot
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}
