using AutoMapper;
using FluentAssertions;
using InnovaApp.API.Controllers;
using InnovaApp.API.Mapper;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Test
{
    public class UserControllerIntegrationTestWithInMemoryDb : BaseControllerIntegrationTest
    {
        private readonly IMapper _mapper;

        public UserControllerIntegrationTestWithInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testdb").Options;
            SetContextOptions(options);
            Seed();


            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AppMaper()));
            _mapper = new AutoMapper.Mapper(configuration);
        }


        [Fact]
        public async Task CreateUser_WhenPasswordLengthLessThan6_CreateNewUser()
        {
            var request = new UserCreateRequestDto { Password = "123456", Email = "ahmet@outlook.com" };
            await using (var context = new AppDbContext(ContextOptions))
            {
                //Arrange

                var userRepository = new UserRepository(context);
                var unitOfWork = new UnitOfWork(context);
                var controller = new UsersController(userRepository, unitOfWork, _mapper);


                // Act
                await controller.CreateUser(request);
            }

            await using (var context = new AppDbContext(ContextOptions))
            {
                var userRepository = new UserRepository(context);

                var userList = await userRepository.GetAll();


                var hasNewUser = userList.Any(x => x.Email == request.Email);

                userList.Should().HaveCount(3);
                hasNewUser.Should().BeTrue();
            }
        }
    }
}