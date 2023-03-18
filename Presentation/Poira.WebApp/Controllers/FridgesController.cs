using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poira.Application.Commands.FridgeCommands.CreateFridge;
using Poira.Application.Queries.FridgeQueries.GetAllFridges;
using Poira.Domain.Models;
using Poira.WebApp.Infrastructure;
using Poira.WebApp.Models.Fridge;

namespace Poira.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgesController : ApiController
{
    private readonly IMapper _mapper;

    public FridgesController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<Fridge>>> GetAll()
    {
        var query = new GetAllFridgesQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<Fridge>> Create([FromBody] CreateFridgeDto createFridgeDto)
    {
        var command = _mapper.Map<CreateFridgeCommand>(createFridgeDto);
        var fridge = await Mediator.Send(command);
        return Ok(fridge);
    }
}