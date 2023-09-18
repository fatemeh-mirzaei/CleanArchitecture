namespace Sample.Application.DTOs
{
    public class GetUserDto : UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime RegisterDate { get; set; }
    }

}
