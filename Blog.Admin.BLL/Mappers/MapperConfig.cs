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
        }
    }
}
