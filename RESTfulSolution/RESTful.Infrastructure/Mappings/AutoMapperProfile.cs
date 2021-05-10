using AutoMapper;
using RESTful.Core.DTOs;
using RESTful.Core.Entities;

namespace RESTful.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Avoire le mm prop name ou le configurer.
            CreateMap<Post, PostDto>().ReverseMap();
        }

    }
}
