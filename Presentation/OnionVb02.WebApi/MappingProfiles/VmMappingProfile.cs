using AutoMapper;
using OnionVb02.Application.DTOClasses;
using OnionVb02.PresentationContract.RequestModels.Categories;
using OnionVb02.PresentationContract.RequestModels.AppUserProfiles;
using OnionVb02.PresentationContract.RequestModels.AppUsers;
using OnionVb02.PresentationContract.RequestModels.OrderDetails;
using OnionVb02.PresentationContract.RequestModels.Orders;
using OnionVb02.PresentationContract.RequestModels.Products;
using OnionVb02.PresentationContract.ResponseModels.AppUserProfiles;
using OnionVb02.PresentationContract.ResponseModels.AppUsers;
using OnionVb02.PresentationContract.ResponseModels.Categories;
using OnionVb02.PresentationContract.ResponseModels.OrderDetails;
using OnionVb02.PresentationContract.ResponseModels.Orders;
using OnionVb02.PresentationContract.ResponseModels.Products;

namespace OnionVb02.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<ProductDto, ProductResponseModel>();

            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();
            CreateMap<OrderDto, OrderResponseModel>();

            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();

            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<AppUserDto, AppUserResponseModel>();

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();
        }
    }
}
