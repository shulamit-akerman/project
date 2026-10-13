using AutoMapper;
using BLL.Repositories;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NAAMA.DTOs;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/vehicles")]
public sealed class VehiclesController(
    IVehicleRepository repository,
    IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetAll()
    {
        var vehicles = await repository.GetAllAsync();
        return Ok(mapper.Map<IReadOnlyList<VehicleDto>>(vehicles));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VehicleDto>> GetById(int id)
    {
        var vehicle = await repository.GetByIdAsync(id);
        return vehicle is null
            ? NotFound()
            : Ok(mapper.Map<VehicleDto>(vehicle));
    }

    [HttpGet("by-driver/{driverId:int}")]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetByDriverId(int driverId)
    {
        var vehicles = await repository.GetByDriverIdAsync(driverId);
        return Ok(mapper.Map<IReadOnlyList<VehicleDto>>(vehicles));
    }

    [HttpPost]
    public async Task<ActionResult<VehicleDto>> Create(CreateVehicleDto dto)
    {
        var vehicle = mapper.Map<Vehicle>(dto);
        var created = await repository.AddAsync(vehicle);
        var response = mapper.Map<VehicleDto>(created);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.VehicleId },
            response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateVehicleDto dto)
    {
        var vehicle = await repository.GetByIdAsync(id);
        if (vehicle is null)
        {
            return NotFound();
        }

        mapper.Map(dto, vehicle);
        await repository.UpdateAsync(id, vehicle);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicle = await repository.GetByIdAsync(id);
        if (vehicle is null)
        {
            return NotFound();
        }

        await repository.DeleteAsync(id);
        return NoContent();
    }
}
