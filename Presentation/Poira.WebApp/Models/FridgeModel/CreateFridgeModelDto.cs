using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Poira.Application.Commands.FridgeModelCommands.CreateFridgeModel;
using Poira.Application.Common.Mappings;

namespace Poira.WebApi.Models.FridgeModel;

public class CreateFridgeModelDto : IMapWith<CreateFridgeModelCommand>
{
    [Required] public string Name { get; set; }
    [Required] public DateTime Year { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFridgeModelDto, CreateFridgeModelCommand>()
            .ForMember(
                command => command.Name,
                expression => expression.MapFrom(expression => expression.Name))
            .ForMember(
                command => command.Year,
                expression => expression.MapFrom(expression => expression.Year));
    }
}