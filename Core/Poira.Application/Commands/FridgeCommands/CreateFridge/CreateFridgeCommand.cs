using MediatR;
using Poira.Domain.Models;

namespace Poira.Application.Commands.FridgeCommands.CreateFridge;

public class CreateFridgeCommand : IRequest<Fridge>
{
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string FridgeModelName { get; set; }
}