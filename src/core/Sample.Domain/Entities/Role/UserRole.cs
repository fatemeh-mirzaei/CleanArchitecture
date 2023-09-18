using Microsoft.AspNetCore.Identity;

namespace Sample.Domain
{
    public class UserRole : IdentityUserRole<Guid>, IBaseDomainEntity
    {
        #region Propertise

        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        #endregion

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
