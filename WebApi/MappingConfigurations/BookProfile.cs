using AutoMapper;
using WebApi.Models;
using WebApi.ViewModels;

namespace WebApi.MappingConfigurations
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookVM>();
        }
    }
}