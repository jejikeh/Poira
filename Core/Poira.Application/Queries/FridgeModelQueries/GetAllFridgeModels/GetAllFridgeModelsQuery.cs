using MediatR;
using Poira.Domain.Models;

namespace Poira.Application.Queries.FridgeModelQueries.GetAllFridgeModels;

public class GetAllFridgeModelsQuery : IRequest<ICollection<FridgeModel>>
{
    
}