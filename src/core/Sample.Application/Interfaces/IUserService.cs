using Sample.Application.DTOs;

namespace Sample.Application.Interfaces
{
    public interface IUserService
    {
        Task<FilterUserDto> GetAllUsers(FilterUserDto filter);
        Task<List<GetUserDto>> GetAllUsers();
        Task<GetUserDto> GetUserById(CancellationToken cancellationToken, Guid userId);
        public Task CreateUser(CreateUserDto userDto, CancellationToken cancellationToken);
        Task UpdateUser(UpdateUserDto userDto, CancellationToken cancellationToken);
    }
}
