using AutoMapper;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.MappingConfigurations
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorVM>();
        }
    }
}