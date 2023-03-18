using MediatR;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Commands.FridgeModelCommands.CreateFridgeModel;

public class CreateFridgeModelCommandHandler : IRequestHandler<CreateFridgeModelCommand, FridgeModel>
{
    private readonly IFridgeModelRepository _fridgeModelRepository;

    public CreateFridgeModelCommandHandler(IFridgeModelRepository fridgeModelRepository)
    {
        _fridgeModelRepository = fridgeModelRepository;
    }
    
    public async Task<FridgeModel> Handle(CreateFridgeModelCommand request, CancellationToken cancellationToken)
    {
        return await _fridgeModelRepository.CreateFridgeModel(request.Name, request.Year);
    }
}