namespace InnovaApp.API.Services
{
    public class UserService(ISmsService smsService)
    {
        public async Task CreateUser(UserCreateRequestDto request)
        {
            if (request.Password.Length > 6)
            {
                throw new Exception("Şifre, 6 karakterden küçük olamaz");
            }
            //create user

            //save user to database
            // sent to sms;

            smsService.SendSsms(request.Phone, "Hoşgeldin mesajı");
        }
    }
}