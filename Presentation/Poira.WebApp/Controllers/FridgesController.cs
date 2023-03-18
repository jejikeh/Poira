using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poira.Application.Commands.FridgeCommands.CreateFridge;
using Poira.Application.Queries.FridgeModelQueries.GetAllFridgeModels;
using Poira.Application.Queries.FridgeQueries.GetAllFridges;
using Poira.Domain.Models;
using Poira.WebApi.Infrastructure;
using Poira.WebApi.Models.Fridge;

namespace Poira.WebApi.Controllers;

[Route("api/[controller]")]
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