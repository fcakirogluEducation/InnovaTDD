using InnovaApp.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InnovaApp.API.Test
{
    public class BaseControllerIntegrationTest
    {
        protected DbContextOptions<AppDbContext>? ContextOptions { get; set; }

        protected void SetContextOptions(DbContextOptions<AppDbContext>? contextOptions)
        {
            ContextOptions = contextOptions;
        }


        public void Seed()
        {
            using var context = new AppDbContext(ContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //create user
            var user = new User() { Email = "ahmet@outlook.com", Password = "123456" };
            var user2 = new User() { Email = "mehmet@outlook.com", Password = "654321" };

            context.Users.AddRange(user, user2);
            context.SaveChanges();
        }
    }
}