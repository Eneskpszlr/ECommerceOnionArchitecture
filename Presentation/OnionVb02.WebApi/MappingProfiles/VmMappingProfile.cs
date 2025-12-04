using AutoMapper;
using OnionVb02.Application.DTOClasses;
using OnionVb02.WebApi.RequestModels.Categories;
using OnionVb02.WebApi.ResponseModels.Categories;

namespace OnionVb02.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
