using AutoMapper;
using MediatR;
using Poira.Application.Interfaces;

namespace Poira.Application.Queries.ProductQueries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsViewModel>
{
    private IProductRepository _productRepository;
    private IMapper _mapper;

    public GetProductDetailsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductDetailsViewModel> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var productById = await _productRepository.GetProductById(request.Id);
        return _mapper.Map<ProductDetailsViewModel>(productById);
    }
}