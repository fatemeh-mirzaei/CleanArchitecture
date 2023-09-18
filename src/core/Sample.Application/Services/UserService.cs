using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sample.Application.DTOs;
using Sample.Application.DTOs.Validation;
using Sample.Application.Interfaces;
using Sample.Application.Persistence.Contracts;
using Sample.Domain;
using Sample.Utilities;

namespace Sample.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<FilterUserDto> GetAllUsers(FilterUserDto filter)
        {
            var userQuery = _mapper.ProjectTo<GetUserDto>(_userRepository.TableNoTracking);

            if (filter.SearchBox != null) userQuery = userQuery.Where(u => u.UserName == filter.SearchBox);

            if (filter.RegisterDate.HasValue) userQuery = userQuery.Where(u => u.RegisterDate == filter.RegisterDate.Value.ToMiladi());

            if (filter.SearchBox != null) userQuery = userQuery.Where(u => u.FirstName.Contains(filter.SearchBox) || u.LastName.Contains(filter.SearchBox) || u.UserName == filter.SearchBox);

            var pageCount = (int)Math.Ceiling(await userQuery.CountAsync() / (double)filter.PageSize);

            var pager = Pager.Build(pageCount, filter.PageId, filter.PageSize);

            var user = await userQuery.Paging(pager).ToListAsync();

            return filter.SetUser(user).SetPaging(pager);
        }
        public async Task<List<GetUserDto>> GetAllUsers()
        {
            var users = await _mapper.ProjectTo<GetUserDto>(_userRepository.TableNoTracking).ToListAsync();

            return users;
        }
        public async Task<GetUserDto> GetUserById(CancellationToken cancellationToken, Guid userId)
        {
            var user = _mapper.Map<GetUserDto>(await _userRepository.GetByIdAsync(cancellationToken, userId));

            return user;
        }

        public async Task CreateUser(CreateUserDto userDto, CancellationToken cancellationToken)
        {
            var results = new CreateUserDtoValidator().Validate(userDto);
            if (!results.IsValid)
            {
                throw new Exception("Not Valid");
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(user, cancellationToken);
        }

        public async Task UpdateUser(UpdateUserDto userDto, CancellationToken cancellationToken)
        {
            var results = new UpdateUserDtoValidator().Validate(userDto);
            if (!results.IsValid)
            {
                throw new Exception("Not Valid");
            }

            var user = _mapper.Map<User>(userDto);
            await _userRepository.UpdateAsync(user, cancellationToken);
        }


    }
}
