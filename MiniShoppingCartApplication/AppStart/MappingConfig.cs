using MiniShoppingCartApplication.Models;
using MiniShoppingCartApplication.ViewModels;

namespace MiniShoppingCartApplication.AppStart
{
    public static class MappingConfig
    {
        public static void RegisterMapps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap().MaxDepth(1);
                config.CreateMap<Customer, CustomerDto>().ReverseMap().MaxDepth(1);
                config.CreateMap<OrderItem, OrderItemDto>().ReverseMap().MaxDepth(1);
                config.CreateMap<CustomerOrder, CustomerOrderDto>().ReverseMap().MaxDepth(1);
            });
        }
    }
}
