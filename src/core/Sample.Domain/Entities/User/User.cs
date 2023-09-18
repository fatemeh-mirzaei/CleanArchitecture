using Microsoft.AspNetCore.Identity;
using Sample.Domain.Enums;

namespace Sample.Domain
{
    public class User : IdentityUser<Guid>, IBaseDomainEntity
    {
        #region Propertise
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        #endregion

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

}
