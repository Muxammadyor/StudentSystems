using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.Users
{
    public interface IUserFactory
    {
        UserDto MapToUserDto(User user);
        User MapToUser(UserForCreationDto userForCreationDto);
        void MapToUser(User storageUser, UserForModificationDto userForCreationDto);
    }
}
