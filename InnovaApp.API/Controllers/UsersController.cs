using AutoMapper;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InnovaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        : ControllerBase
    {
        //create user crud operation
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequestDto request)
        {
            try
            {
                if (request.Password.Length > 6)
                {
                    throw new Exception("Şifre, 6 karakterden küçük olamaz");
                }

                //stub
                var user = mapper.Map<User>(request);

                if (user == null)
                {
                    return BadRequest();
                }


                userRepository.CreateUser(user);
                await unitOfWork.SaveChanges();
                return Ok("kullanıcı oluşturuldu");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await userRepository.GetAll();


            if (users is null)
            {
                return NotFound();
            }

            return Ok(users);
        }


        //[HttpGet]
        //public async Task<IActionResult> Update(UserUpdateRequestDto request)
        //{
        //    try
        //    {
        //        await userService.UpdateUser(request);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await userService.DeleteUser(id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}