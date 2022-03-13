using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Controllers;
using WebAPI.PhoneBook.Data;
using WebAPI.PhoneBook.Interfaces;
using Xunit;

namespace WebAPI.PhoneBook.Test
{
    public class UsersApiControllerTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UsersController _controller;

        private List<User> users;
        public UsersApiControllerTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new UsersController(_mockRepo.Object);

            users = new List<User>()
            {
                new User { UUID = 1, Name = "John", Surname = "Doe", Company = "Amazon" },
                new User {UUID=2, Name="Ricky", Surname="More", Company="Amazon"}
            };
        }

        [Fact]
        public async void GetAll() //GetAllAsync
        {
            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(users);
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnUsers = Assert.IsAssignableFrom<IEnumerable<User>>
                (okResult.Value);

            Assert.Equal<int>(2, returnUsers.ToList().Count);
        }

        [Theory]
        [InlineData(0)]
        public async void GetByID_InvalidID_ReturnNotFound(int UserID)
        {
            User user = null;
            _mockRepo.Setup(x => x.GetByIdAsync(UserID)).ReturnsAsync(user);
            var result = await _controller.GetById(UserID);
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetByID_Valid_ReturnOkResult(int UserID)
        {
            var user = users.First(x => x.UUID == UserID);
            _mockRepo.Setup(x => x.GetByIdAsync(UserID)).ReturnsAsync(user);
            var result = await _controller.GetById(UserID);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(UserID, returnUser.UUID);
            Assert.Equal(user.Name, returnUser.Name);
        }
        [Theory]
        [InlineData(6)]
        public async void Remove_IdInvalid_ReturnNotFound(int UserID)
        {
            User user = null;
            _mockRepo.Setup(x => x.GetByIdAsync(UserID)).ReturnsAsync(user);
            var resultNotFound = await _controller.Remove(UserID);
            Assert.IsType<NotFoundResult>(resultNotFound);
        }
    }
}
