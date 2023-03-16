using MediatR;
using Poira.Domain.Models;

namespace Poira.Application.Commands.FridgeModelCommands.CreateFridgeModel;

public class CreateFridgeModelCommand : IRequest<FridgeModel>
{
    public string Name { get; set; }
    public DateTime Year { get; set; }
}