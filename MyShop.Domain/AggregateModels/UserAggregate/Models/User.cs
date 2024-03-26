using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.AggregateModels.UserAggregate.Models
{
    public class User : AggregateRoot<long>
    {
        public string UserName { get; private set; }
        
        public string? PasswordHasded { get; private set; }
        
        public string FullName { get; private set; }
        
        public string Email { get; private set; }
        
        public string? PhoneNumber { get; private set; }
        
        public string Avatar { get; private set; }
        
        public bool TwoFactorAuthEnable { get; private set; }
        
        public string? TwoFactorSecretKey { get; private set; }
        
        public DateTime CreatedDate { get; private set; }
        
        public List<UserRole> Roles { get; private set; }

        public User(
            string userName, 
            string? passwordHasded, 
            string fullName, 
            string email, 
            string? phoneNumber, 
            string avatar,
            bool twoFactorAuthEnable,
            string? twoFactorSecretKey)
        {
            UserName = userName;
            PasswordHasded = passwordHasded;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            TwoFactorAuthEnable = twoFactorAuthEnable;
            TwoFactorSecretKey = twoFactorSecretKey;
        }

        public void AddRole(long roleId, long branchId)
        {
            Roles = Roles ?? new List<UserRole>();
            if (!Roles.Any(r => r.RoleId == roleId && r.BranchId == branchId))
            {
                Roles.Add(new UserRole(Id, branchId, roleId));
            }
        }
    }
}
