using Microsoft.AspNetCore.Identity;

namespace Sample.Domain
{
    public class Role : IdentityRole<Guid>, IBaseDomainEntity
    {
        #region Propertise

        //عنوان فارسی
        public string Title { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        #endregion
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
