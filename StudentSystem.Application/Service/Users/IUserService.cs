using StudentSystem.Application.DTO;
using StudentSystem.Domain.Enums;

namespace StudentSystem.Application.Service.Users
{
    public interface IUserService
    {
        ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
        ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId);

        IQueryable<UserDto> RetriveUserBySubString(string subString);
        IQueryable<UserDto> RetrieveUserByRole(UserRole role);
        ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
        ValueTask<UserDto> RemoveUserAsync(Guid userId);
    }
}
