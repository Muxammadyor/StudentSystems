using Moq;
using StudentSystem.Application.DTO;
using StudentSystem.Application.Service.Users;
using StudentSystem.Domain.Entities;
using StudentSystem.Domain.Enums;
using StudentSystem.Domain.Exceptions;
using StudentSystem.Infrastructure.Repository;

namespace StudentSysteam.UnitTest.Servive.Users
{

    public partial class UserServiceTests
    {
        [Fact]
        public async Task Should_ThrowNotFoundExceptionOnRetrieveById()
        {
            var randomUserId = Guid.NewGuid();
            User storageUser = null;

            userMockRepository.Setup(mock => mock.SelectByIdWithDetailsAsync(
                    user => user.Id == randomUserId,
                    new string[] { }));

            ValueTask<UserDto> userDtoTask = this.userService
                .RetrieveUserByIdAsync(randomUserId);

            await Assert.ThrowsAsync<NotFoundException>(userDtoTask.AsTask);
        }

        [Fact]
        public async Task RetrieveUserByIdAsync_ReturnsCorrectUser()
        {
            var userId = Guid.NewGuid();
            var storageUser = new User { Id = userId, FirstName = "Ali" };
            var userDto = new UserDto(userId, "Ali", "Valiyav", "ali@gmail.com","+998942142336",DateTime.Now, UserRole.Admin);

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(x => x.SelectByIdAsync(userId))
                .ReturnsAsync(storageUser);

            var userFactoryMock = new Mock<IUserFactory>();
            userFactoryMock
                .Setup(x => x.MapToUserDto(storageUser))
                .Returns(userDto);

            var userManagement = new UserService(userRepositoryMock.Object, userFactoryMock.Object);

            var result = await userManagement.RetrieveUserByIdAsync(userId);

            userRepositoryMock.Verify(x => x.SelectByIdAsync(userId), Times.Once);
            userFactoryMock.Verify(x => x.MapToUserDto(storageUser), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(userId, result.id);
            Assert.Equal("Ali", result.firstName);
        }

    }
}
