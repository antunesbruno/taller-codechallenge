using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Interfaces;
using Taller_CodeChallenge.Controllers;
using Xunit;

namespace Taller.CodeChallenge.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly Mock<ILogger<UsersController>> _loggerMock;
        private readonly Mock<IUsersAdapter> _usersAdapterMock;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _loggerMock = new Mock<ILogger<UsersController>>();
            _usersAdapterMock = new Mock<IUsersAdapter>();
            _controller = new UsersController(_loggerMock.Object, _usersAdapterMock.Object);
        }

        [Fact]
        public async Task GetUsersByName_ReturnsOk_WhenUsersFound()
        {

            var userName = "testuser";
            var users = new List<UserModel> { new UserModel { IdUser = "1", UserName = "testuser" } };
            _usersAdapterMock.Setup(x => x.GetUsers(userName.ToLower(), It.IsAny<CancellationToken>())).ReturnsAsync(users);


            var result = await _controller.GetUsersByName(userName, CancellationToken.None);


            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task GetUsersByName_ReturnsNotFound_WhenUsersNotFound()
        {

            var userName = "testuser";
            _usersAdapterMock.Setup(x => x.GetUsers(userName.ToLower(), It.IsAny<CancellationToken>())).ReturnsAsync((List<UserModel>)null);


            var result = await _controller.GetUsersByName(userName, CancellationToken.None);


            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task InsertUserInMemoryDatabase_ReturnsCreated_WhenUserAdded()
        {

            var userModel = new UserModelToAdd { UserName = "newuser" };
            var userId = Guid.NewGuid();
            _usersAdapterMock.Setup(x => x.AddUsers(userModel, It.IsAny<CancellationToken>())).ReturnsAsync(userId);


            var result = await _controller.InsertUserInMemoryDatabase(userModel, CancellationToken.None);


            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal($"getUsers/{userId}", createdResult.Location);
        }

        [Fact]
        public async Task InsertUserInMemoryDatabase_ReturnsBadRequest_WhenUserNotAdded()
        {

            var userModel = new UserModelToAdd { UserName = "newuser" };
            _usersAdapterMock.Setup(x => x.AddUsers(userModel, It.IsAny<CancellationToken>())).ReturnsAsync(Guid.Empty);


            var result = await _controller.InsertUserInMemoryDatabase(userModel, CancellationToken.None);


            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Error to create a new User", badRequestResult.Value);
        }

        [Fact]
        public async Task DeleteUserById_ReturnsOk_WhenUserDeleted()
        {

            var userId = Guid.NewGuid();
            _usersAdapterMock.Setup(x => x.DeleteUsersById(userId, It.IsAny<CancellationToken>())).ReturnsAsync(true);


            var result = await _controller.DeleteUserById(userId, CancellationToken.None);


            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task DeleteUserById_ReturnsBadRequest_WhenUserNotDeleted()
        {

            var userId = Guid.NewGuid();
            _usersAdapterMock.Setup(x => x.DeleteUsersById(userId, It.IsAny<CancellationToken>())).ReturnsAsync(false);


            var result = await _controller.DeleteUserById(userId, CancellationToken.None);


            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal($"Error to delete a user with ID {userId}", badRequestResult.Value);
        }
    }
}
