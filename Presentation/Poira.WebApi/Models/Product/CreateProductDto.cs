using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Poira.Application.Commands.ProductCommands.CreateProduct;
using Poira.Application.Common.Mappings;

namespace Poira.WebApi.Models.Product;

public class CreateProductDto : IMapWith<CreateProductCommand>
{
    [Required] public string Name { get; set; }
    [Required] public int DefaultQuantity { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, CreateProductCommand>()
            .ForMember(
                command => command.Name,
                expression => expression.MapFrom(expression => expression.Name))
            .ForMember(
                command => command.DefaultQuantity,
                expression => expression.MapFrom(expression => expression.DefaultQuantity));
    }
}