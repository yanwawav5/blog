using AutoMapper;
using Blog.Dto.BlogAdmin;
using Blog.Model;

namespace Blog.Admin.BLL.Mappers
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            // tbl_category转CategoryViewDto
            CreateMap<tbl_category, CategoryViewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence));

            // tbl_tag转TagViewDto
            CreateMap<tbl_tag, TagViewDto>()
                .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.Sequence));

            // tbl_user转UserViewDto
            CreateMap<tbl_user, UserViewDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.RegisterAt, opt => opt.MapFrom(src => src.RegisterAt))
                .ForMember(dest => dest.LastLoginAt, opt => opt.MapFrom(src => src.LastLoginAt))
                .ForMember(dest => dest.LastLoginAddr, opt => opt.MapFrom(src => src.LastLoginAddr));
        }
    }
}
