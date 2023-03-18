using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Poira.Application.Commands.FridgeCommands.CreateFridge;
using Poira.Application.Common.Mappings;

namespace Poira.WebApp.Models.Fridge;

public class CreateFridgeDto : IMapWith<CreateFridgeCommand>
{
    [Required] public string Name { get; set; }
    [Required] public string OwnerName { get; set; }
    [Required] public string FridgeModelName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFridgeDto, CreateFridgeCommand>()
            .ForMember(
                command => command.OwnerName,
                expression => expression.MapFrom(expression => expression.OwnerName))
            .ForMember(
                command => command.Name,
                expression => expression.MapFrom(expression => expression.Name))
            .ForMember(
                command => command.FridgeModelName,
                expression => expression.MapFrom(expression => expression.FridgeModelName));
    }
}