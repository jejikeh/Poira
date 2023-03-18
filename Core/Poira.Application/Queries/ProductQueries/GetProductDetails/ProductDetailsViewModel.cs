using AutoMapper;
using Poira.Application.Common.Mappings;
using Poira.Domain.Models;

namespace Poira.Application.Queries.ProductQueries.GetProductDetails;

public class ProductDetailsViewModel : IMapWith<Product>
{
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDetailsViewModel>()
            .ForMember(productDetailsViewModel => 
                productDetailsViewModel.Name, member => member.MapFrom(product => product.Name))
            .ForMember(productDetailsViewModel => 
                productDetailsViewModel.DefaultQuantity, member => member.MapFrom(product => product.DefaultQuantity));
    }
}