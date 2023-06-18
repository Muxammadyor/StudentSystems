using StudentSystem.Application.DTO;
using StudentSystem.Domain.Enums;

namespace StudentSystem.Application.Service.Users
{
    public interface IUserService
    {
        ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
        ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId);

        IQueryable<UserDto> RetriveUserBySubStringStudent(string subString);
        IQueryable<UserDto> RetriveUserBySubStringTeacher(string subString);
        IQueryable<UserDto> RetriveUserByPhoneNumberTeacher(string phoneNumber);
        IQueryable<UserDto> RetriveUserByPhoneNumberStudent(string phoneNumber);
        IQueryable<UserDto> RetriveUserByAgeStudent(int age);
        IQueryable<UserDto> RetriveUserByAgeTeacher(int age);
        IQueryable<UserDto> RetrieveUserByRole(UserRole role);
        ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
        ValueTask<UserDto> RemoveUserAsync(Guid userId);
    }
}
