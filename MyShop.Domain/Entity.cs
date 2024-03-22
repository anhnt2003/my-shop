using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
