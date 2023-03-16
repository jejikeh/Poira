using MediatR;
using Poira.Domain.Models;

namespace Poira.Application.Queries.FridgeQueries.GetAllFridges;

public class GetAllFridgesQuery : IRequest<ICollection<Fridge>>
{
    
}