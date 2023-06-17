using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;
using StudentSystem.Infrastructure.Authentication;

namespace StudentSystem.Application.Service.Users
{
    public class UserFactory : IUserFactory
    {
        private readonly IPasswordHasher passwordHasher;

        public UserFactory(IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public User MapToUser(UserForCreationDto userForCreationDto)
        {
            string randomSalt = Guid.NewGuid().ToString();

            return new User
            {
                FirstName = userForCreationDto.firstName,
                LastName = userForCreationDto.lastName,
                Email = userForCreationDto.email,
                Role = userForCreationDto.userRole,
                PhoneNumber = userForCreationDto.phoneNumber,
                BirthDate = userForCreationDto.birthDate,

                Salt = randomSalt,

                PasswordHash = this.passwordHasher.Encrypt(
                    password: userForCreationDto.password,
                    salt: randomSalt),

            };
        }

        public void MapToUser(User storageUser, UserForModificationDto userForCreationDto)
        {
            throw new NotImplementedException();
        }

        public UserDto MapToUserDto(User user)
        {
            return new UserDto(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.PhoneNumber,
                user.BirthDate,
                user.Role
                );
        }
    }
}
