using MediatR;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Queries.FridgeModelQueries.GetAllFridgeModels;

public class GetAllFridgeModelsQueryHandler : IRequestHandler<GetAllFridgeModelsQuery, ICollection<FridgeModel>>
{
    private readonly IFridgeModelRepository _fridgeModelRepository;

    public GetAllFridgeModelsQueryHandler(IFridgeModelRepository fridgeModelRepository)
    {
        _fridgeModelRepository = fridgeModelRepository;
    }
    
    public async Task<ICollection<FridgeModel>> Handle(GetAllFridgeModelsQuery request, CancellationToken cancellationToken)
    {
        return await _fridgeModelRepository.GetAllFridgeModels();
    }
}