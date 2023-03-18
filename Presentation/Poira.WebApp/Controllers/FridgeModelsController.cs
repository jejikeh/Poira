using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poira.Application.Commands.FridgeModelCommands.CreateFridgeModel;
using Poira.Application.Queries.FridgeModelQueries.GetAllFridgeModels;
using Poira.Domain.Models;
using Poira.WebApi.Models.FridgeModel;
using Poira.WebApp.Infrastructure;

namespace Poira.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgeModelsController : ApiController
{
    private readonly IMapper _mapper;

    public FridgeModelsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<FridgeModel>>> GetAll()
    {
        var query = new GetAllFridgeModelsQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<FridgeModel>> Create([FromBody] CreateFridgeModelDto createFridgeModelDto)
    {
        var command = _mapper.Map<CreateFridgeModelCommand>(createFridgeModelDto);
        var fridge = await Mediator.Send(command);
        return Ok(fridge);
    }
}