using Sample.Domain.Enums;

namespace Sample.Application.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Status Status { get; set; }
    }
}
