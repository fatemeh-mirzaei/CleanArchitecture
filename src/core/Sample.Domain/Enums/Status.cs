using System.ComponentModel.DataAnnotations;

namespace Sample.Domain.Enums
{
    public enum Status : byte
    {
        [Display(Name = "فعال")]
        Active = 1,
        [Display(Name = "در انتظار تایید")]
        Waiting = 2,
        [Display(Name = "رد شده")]
        Failed = 3,
        [Display(Name = "حذف شده")]
        Deleted = 4,
    }
}
