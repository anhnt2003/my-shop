using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.AggregateModels.UserAggregate.Models
{
    public class UserRole : ValueObject
    {
        public long UserId { get; private set; }
        
        public long BranchId { get; private set; }
        
        public long RoleId { get; private set; }

        public UserRole(long userId, long branchId, long roleId)
        {
            UserId = userId;
            BranchId = branchId;
            RoleId = roleId;    
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return BranchId;
            yield return RoleId;
        }
    }
}
