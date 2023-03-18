using MediatR;
using Poira.Application.Interfaces;
using Poira.Domain.Models;

namespace Poira.Application.Commands.ProductCommands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.CreateProduct(request.Name, request.DefaultQuantity);
    }
}