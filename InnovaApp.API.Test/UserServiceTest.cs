using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Moq;

namespace InnovaApp.API.Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateUser_GreaterThanPasswordLength_6_ThrowExceptions()
        {
            //Arrange
            var userCreateRequestDto = new UserCreateRequestDto
            {
                Password = "1234567"
            };

            var mockSmsService = new Mock<ISmsService>();
            var stubUserRepository = new Mock<IUserRepository>();
            // mockSmsService.Setup(x => x.SendSsms(userCreateRequestDto.Phone, "adsfdsfdf"));


            var sut = new UserService(mockSmsService.Object, stubUserRepository.Object);


            //Act
            var exception = await Assert.ThrowsAsync<Exception>(() => sut.CreateUser(userCreateRequestDto));

            //Assert
            Assert.Equal("Şifre, 6 karakterden küçük olamaz", exception.Message);
        }

        [Fact]
        public async Task CreateUser_LessThanPasswordLength_6_ReturnSuccess()
        {
            //Arrange
            var userCreateRequestDto = new UserCreateRequestDto
            {
                Password = "12345"
            };

            var mockSmsService = new Mock<ISmsService>();
            var userRepository = new Mock<IUserRepository>();
            // mockSmsService.Setup(x => x.SendSsms(userCreateRequestDto.Phone, "adsfdsfdf"));


            var sut = new UserService(mockSmsService.Object, userRepository.Object);


            await sut.CreateUser(userCreateRequestDto);


            mockSmsService.Verify(x => x.SendSsms(userCreateRequestDto.Phone, "Hoşgeldin mesajı"), Times.Once);
        }


        public async Task CreateUser_ExistingEmail_ThrowExceptions()
        {
            //Arrange
            var userCreateRequestDto = new UserCreateRequestDto
            {
                Email = "ahmet@outlook.com"
            };

            var userRepositoryStub = new Mock<IUserRepository>();
            var userSmsServiceMock = new Mock<ISmsService>();
            userRepositoryStub.Setup(x => x.AnySameEmail(userCreateRequestDto.Email)).ReturnsAsync(true);


            var sut = new UserService(userSmsServiceMock.Object, userRepositoryStub.Object);

            var exception = await Assert.ThrowsAsync<Exception>(() => sut.CreateUser(userCreateRequestDto));
            Assert.Equal("Bu email adresi kullanılmaktadır.", exception.Message);
        }


        //public void GetUserById()
        //{
        //    //Arrange
        //    var user = new User();
        //    var mockUserRepository = new Mock<IUserRepository>();
        //    mockUserRepository.Setup(x => x.GetUserById(1)).Returns(user);
        //    var userService = new UserService(mockUserRepository.Object);

        //    //Act
        //    var result = userService.GetUserById(1);

        //    //Assert
        //    Assert.Equal(user, result);
        //}
    }
}