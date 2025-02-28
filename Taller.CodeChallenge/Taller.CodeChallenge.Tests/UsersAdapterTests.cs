using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Entities;
using Taller.CodeChallenge.Domain.Interfaces;
using Taller.CodeChallenge.Infrastructure.Adapters;
using Xunit;

namespace Taller.CodeChallenge.Tests.Adapters
{
    public class UsersAdapterTests
    {
        private readonly Mock<IUsersRepository> _usersRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UsersAdapter _adapter;

        public UsersAdapterTests()
        {
            _usersRepositoryMock = new Mock<IUsersRepository>();
            _mapperMock = new Mock<IMapper>();
            _adapter = new UsersAdapter(_usersRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddUsers_ReturnsUserId_WhenUserAdded()
        {
           
            var userModel = new UserModelToAdd { UserName = "newuser" };
            var userEntity = new Users { Id = Guid.NewGuid(), UserName = "newuser" };
            _mapperMock.Setup(x => x.Map<UserModelToAdd, Users>(userModel)).Returns(userEntity);
            _usersRepositoryMock.Setup(x => x.AddUser(userEntity)).ReturnsAsync(userEntity.Id);

            
            var result = await _adapter.AddUsers(userModel, CancellationToken.None);

           
            Assert.Equal(userEntity.Id, result);
        }

        [Fact]
        public async Task DeleteUsersById_ReturnsTrue_WhenUserDeleted()
        {
           
            var userId = Guid.NewGuid();
            _usersRepositoryMock.Setup(x => x.DeleteUser(userId)).ReturnsAsync(true);

            
            var result = await _adapter.DeleteUsersById(userId, CancellationToken.None);

           
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUsersById_ReturnsFalse_WhenUserNotDeleted()
        {
           
            var userId = Guid.NewGuid();
            _usersRepositoryMock.Setup(x => x.DeleteUser(userId)).ReturnsAsync(false);

            
            var result = await _adapter.DeleteUsersById(userId, CancellationToken.None);

           
            Assert.False(result);
        }

        [Fact]
        public async Task GetUsers_ReturnsUserModels_WhenUsersFound()
        {
           
            var userName = "testuser";
            var userEntities = new List<Users> { new Users { Id = Guid.NewGuid(), UserName = "testuser" } };
            var userModels = new List<UserModel> { new UserModel { IdUser = userEntities[0].Id.ToString(), UserName = "testuser" } };
            _usersRepositoryMock.Setup(x => x.GetUsers(userName)).ReturnsAsync(userEntities);
            _mapperMock.Setup(x => x.Map<List<Users>, List<UserModel>>(userEntities)).Returns(userModels);

            
            var result = await _adapter.GetUsers(userName, CancellationToken.None);

           
            Assert.Equal(userModels, result);
        }
    }
}
