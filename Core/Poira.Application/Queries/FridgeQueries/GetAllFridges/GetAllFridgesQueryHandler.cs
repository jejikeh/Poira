using MediatR;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Queries.FridgeQueries.GetAllFridges;

public class GetAllFridgesQueryHandler : IRequestHandler<GetAllFridgesQuery, ICollection<Fridge>>
{
    private readonly IFridgeRepository _fridgeRepository;

    public GetAllFridgesQueryHandler(IFridgeRepository fridgeRepository)
    {
        _fridgeRepository = fridgeRepository;
    }
    
    public async Task<ICollection<Fridge>> Handle(GetAllFridgesQuery request, CancellationToken cancellationToken)
    {
        return await _fridgeRepository.GetAllFridges();
    }
}