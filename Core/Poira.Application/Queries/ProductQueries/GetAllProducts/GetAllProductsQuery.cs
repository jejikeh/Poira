using MediatR;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Queries.ProductQueries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ICollection<Product>>
{
}