using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poira.Application.Commands.FridgeModelCommands.CreateFridgeModel;
using Poira.Application.Commands.ProductCommands.CreateProduct;
using Poira.Application.Queries.FridgeModelQueries.GetAllFridgeModels;
using Poira.Application.Queries.ProductQueries.GetAllProducts;
using Poira.Domain.Models;
using Poira.WebApi.Infrastructure;
using Poira.WebApi.Models.FridgeModel;
using Poira.WebApi.Models.Product;

namespace Poira.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductsController : ApiController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Product>>> GetAll()
    {
        var query = new GetAllProductsQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] CreateProductDto createProductDto)
    {
        var command = _mapper.Map<CreateProductCommand>(createProductDto);
        var fridge = await Mediator.Send(command);
        return Ok(fridge);
    }
}