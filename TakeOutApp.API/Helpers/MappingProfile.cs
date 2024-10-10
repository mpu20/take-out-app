using AutoMapper;
using TakeOutApp.API.Models;
using TakeOutApp.API.ViewModels;

namespace TakeOutApp.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginVM, User>();
            CreateMap<RegisterVM, User>();
        }
    }
}
