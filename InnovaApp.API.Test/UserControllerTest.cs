using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using InnovaApp.API.Controllers;
using InnovaApp.API.Mapper;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InnovaApp.API.Test
{
    public class UserControllerTest
    {
        private readonly IMapper _mapper;

        public UserControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AppMaper()));
            _mapper = new AutoMapper.Mapper(configuration);
        }


        [Fact]
        public async Task CreateUser_WhenPasswordLengthGreaterThan6_ReturnsBadRequest()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var controller = new UsersController(userRepository.Object, unitOfWork.Object, _mapper);
            var request = new UserCreateRequestDto { Password = "1234567", Email = "ahmet@outlook.com" };

            // Act
            var result = await controller.CreateUser(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Şifre, 6 karakterden küçük olamaz", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateUser_WhenPasswordLengthLessThan6_ReturnsOk()
        {
            // Arrange
            var userRepositoryStub = new Mock<IUserRepository>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            var mapperStub = new Mock<IMapper>();


            var controller = new UsersController(userRepositoryStub.Object, unitOfWorkStub.Object, _mapper);
            var request = new UserCreateRequestDto { Password = "123456", Email = "ahmet@outlook.com" };

            // Act
            var result = await controller.CreateUser(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            okResult.Value.Should().Be("kullanıcı oluşturuldu");
        }


        [Fact]
        public async Task GetAll_WhenUsersExist_ReturnsOk()
        {
            // Arrange
            var userRepositoryStub = new Mock<IUserRepository>();
            var unitOfWorkStub = new Mock<IUnitOfWork>();


            var users = new List<User>
            {
                new User { Id = 1, Email = "" },
                new User { Id = 1, Email = "" }
            };

            userRepositoryStub.Setup(repo => repo.GetAll()).ReturnsAsync(users);

            var sut = new UsersController(userRepositoryStub.Object, unitOfWorkStub.Object, _mapper);


            var result = await sut.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            //var resultUserList=okResult.Value as List<User>;

            //resultUserList.Count.Should().Be(users.Count);

            okResult.Value.Should().BeEquivalentTo(users);
        }
    }
}