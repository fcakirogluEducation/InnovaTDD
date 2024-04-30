using InnovaApp.API.Repositories;

namespace InnovaApp.API.Services
{
    public class UserService(ISmsService smsService, IUserRepository userRepository)
    {
        public async Task CreateUser(UserCreateRequestDto request)
        {
            if (request.Password.Length > 6)
            {
                throw new Exception("Şifre, 6 karakterden küçük olamaz");
            }

            if (await userRepository.AnySameEmail(request.Email))
            {
                throw new Exception("Bu email adresi kullanılmaktadır.");
            }

            //create user

            //save user to database
            // sent to sms;

            smsService.SendSsms(request.Phone, "Hoşgeldin mesajı");
        }
    }
}