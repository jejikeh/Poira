using MediatR;
using Poira.Domain.Models;

namespace Poira.Application.Commands.ProductCommands.CreateProduct;

public class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }
}