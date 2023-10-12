using AutoMapper;
using Entities;
using Entities.ViewModel;

namespace WebApi.Base
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, LoginRp>();

            CreateMap<CategoryRq.InsertDto, Category>();
            CreateMap<CategoryRq.UpdateDto, Category>();
        }
    }
}
