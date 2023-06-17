using StudentSystem.Application.DTO.Users;
using StudentSystem.Domain.Enums;
using StudentSystem.Infrastructure.Repository;

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
}
