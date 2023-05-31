using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BE_CRUD.Services;
using BE_CRUD.Models;

namespace BE_CRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
    private readonly IPetsService petService;
    private readonly ILogger<PetController> _logger;

    public PetController(IPetsService service, ILogger<PetController> logger)
    {
        petService = service;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var actualPet = await petService.GetOne(id);
        return Ok(actualPet);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(petService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pet pet)
    {
        await petService.Post(pet);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Pet pet)
    {
        await petService.Update(id, pet);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var results = await petService.Delete(id);

        if (results)
        {
            return Ok();
        }
        return NotFound();
    }
}
