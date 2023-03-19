using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poira.Application.Commands.ProductCommands.CreateProduct;
using Poira.Application.Queries.ProductQueries.GetAllProducts;
using Poira.Application.Queries.ProductQueries.GetProductDetails;
using Poira.Domain.Models;
using Poira.WebApi.Models.Product;
using Poira.WebApp.Infrastructure;

namespace Poira.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ApiController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ICollection<Product>>> GetAll()
    {
        var query = new GetAllProductsQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsViewModel>> Get(Guid id)
    {
        var query = new GetProductDetailsQuery()
        {
            Id = id
        };
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