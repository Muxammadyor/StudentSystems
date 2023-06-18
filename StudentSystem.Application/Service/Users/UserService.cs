using StudentSystem.Application.DTO;
using StudentSystem.Domain.Enums;
using StudentSystem.Infrastructure.Repository;
using System.Data.SqlTypes;

namespace StudentSystem.Application.Service.Users;

public partial class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;

    public UserService(
        IUserRepository userRepository,
        IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }
    public async ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto)
    {
        ValidateUserForCreationDto(userForCreationDto);

        var newUser = this.userFactory
            .MapToUser(userForCreationDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return this.userFactory.MapToUserDto(addedUser);
    }

    public IQueryable<UserDto> RetriveUserBySubStringStudent(string subString)
    {
        var users = this.userRepository.SelectAll(user => 
        ((user.FirstName.Contains(subString) || user.LastName.Contains(subString))
        && user.Role==UserRole.Student));

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }


    public async ValueTask<UserDto> RemoveUserAsync(Guid userId)
    {
        var storageUser = await this.userRepository
        .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return this.userFactory.MapToUserDto(removedUser);
    }

    public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
    {
        var storageUser = await this.userRepository
        .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        return this.userFactory.MapToUserDto(storageUser);
    }

    public IQueryable<UserDto> RetrieveUserByRole(UserRole role)
    {
        var users = this.userRepository.SelectAll(user =>
                        user.Role==role);

        return users.Select(user =>
            this.userFactory.MapToUserDto(user));
    }

    public ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto)
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserDto> RetriveUserBySubStringTeacher(string subString)
    {
        var users = this.userRepository.SelectAll(user =>
        ((user.FirstName.Contains(subString) || user.LastName.Contains(subString))
        && user.Role == UserRole.Teacher));

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }

    public IQueryable<UserDto> RetriveUserByPhoneNumberTeacher(string phoneNumber)
    {
        var users = this.userRepository.SelectAll(user =>
        ((user.PhoneNumber.Contains(phoneNumber) )
        && user.Role == UserRole.Teacher));

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }

    public IQueryable<UserDto> RetriveUserByPhoneNumberStudent(string phoneNumber)
    {
        var users = this.userRepository.SelectAll(user =>
        ((user.PhoneNumber.Contains(phoneNumber))
        && user.Role == UserRole.Student));

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }

    public IQueryable<UserDto> RetriveUserByAgeStudent(int age)
    {
        var userAge = DateTime.Now.Year - age;
        var users = this.userRepository.SelectAll(user =>
        user.BirthDate.Year<=userAge
        && user.Role == UserRole.Student);

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }

    public IQueryable<UserDto> RetriveUserByAgeTeacher(int age)
    {
        var userAge = DateTime.Now.Year - age;
        var users = this.userRepository.SelectAll(user =>
        user.BirthDate.Year <= userAge
        && user.Role == UserRole.Teacher);

        return users.Select(user =>
           this.userFactory.MapToUserDto(user));
    }
}
