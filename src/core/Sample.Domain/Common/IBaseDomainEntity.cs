namespace Sample.Domain
{
    public interface IBaseDomainEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
