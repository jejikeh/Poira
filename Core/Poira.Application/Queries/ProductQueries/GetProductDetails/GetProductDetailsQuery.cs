using MediatR;

namespace Poira.Application.Queries.ProductQueries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ProductDetailsViewModel>
{
    public Guid Id { get; set; }
}