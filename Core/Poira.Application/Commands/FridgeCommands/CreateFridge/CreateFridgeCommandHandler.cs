using MediatR;
using Poira.Application.Common.Exceptions;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Commands.FridgeCommands.CreateFridge;

public class CreateFridgeCommandHandler : IRequestHandler<CreateFridgeCommand, Fridge>
{
    private readonly IFridgeRepository _fridgeRepository;
    private readonly IFridgeModelRepository _fridgeModelRepository;

    public CreateFridgeCommandHandler(IFridgeRepository fridgeRepository, IFridgeModelRepository fridgeModelRepository)
    {
        _fridgeRepository = fridgeRepository;
        _fridgeModelRepository = fridgeModelRepository;
    }
    
    public async Task<Fridge> Handle(CreateFridgeCommand request, CancellationToken cancellationToken)
    {
        var fridgeModelByName = await _fridgeModelRepository.GetFridgeModelByName(request.FridgeModelName);
        if (fridgeModelByName is null)
            throw new NotFoundException<FridgeModel>(request.FridgeModelName);

        return await _fridgeRepository.CreateFridge(request.Name, request.OwnerName, fridgeModelByName.Id);
    }
}