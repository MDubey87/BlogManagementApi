using AutoMapper;
using Blog.Management.Api.Models;
using Blog.Management.Services.Models;

namespace Blog.Management.Api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogRequest, BlogPost>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));
            CreateMap<BlogPost, BlogResponse>();
        }

    }
}
