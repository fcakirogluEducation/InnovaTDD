using AutoMapper;
using InnovaApp.API.Repositories;
using InnovaApp.API.Services;

namespace InnovaApp.API.Mapper
{
    public class AppMaper : Profile
    {
        public AppMaper()
        {
            CreateMap<UserCreateRequestDto, User>().ReverseMap();
        }
    }
}