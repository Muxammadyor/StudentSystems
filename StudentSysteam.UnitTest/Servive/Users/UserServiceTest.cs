﻿

using Microsoft.AspNetCore.Http;
using Moq;
using StudentSystem.Application.Service.Users;
using StudentSystem.Infrastructure.Repository;

namespace StudentSysteam.UnitTest.Servive.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IUserRepository> userMockRepository;
        private readonly Mock<IUserFactory> userMockFactory;
        private readonly Mock<IHttpContextAccessor> httpMockContextAccessor;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.userMockRepository = new Mock<IUserRepository>();
            this.userMockFactory = new Mock<IUserFactory>();
            this.httpMockContextAccessor = new Mock<IHttpContextAccessor>();

            this.userService = new UserService(
                userRepository: userMockRepository.Object,
                userFactory: userMockFactory.Object);
        }
    }
}
