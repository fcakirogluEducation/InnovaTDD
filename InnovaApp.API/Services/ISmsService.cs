namespace InnovaApp.API.Services
{
    public interface ISmsService
    {
        void SendSsms(string phoneNumber, string message);
    }
}