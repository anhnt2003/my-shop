using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get;}

        void AddDomainEvent(IDomainEvent @Event);

        void ClearDomainEvents();
    }
}
