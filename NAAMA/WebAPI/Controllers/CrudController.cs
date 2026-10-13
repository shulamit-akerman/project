using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public abstract class CrudController<TEntity, TCreateDto, TUpdateDto, TResponseDto, TKey>(IMapper mapper) : ControllerBase
    where TEntity : class
    where TKey : notnull
{
    protected abstract Task<TEntity?> FindAsync(TKey id);
    protected abstract Task<IReadOnlyList<TEntity>> ListAsync();
    protected abstract Task<TEntity> InsertAsync(TEntity entity);
    protected abstract Task UpdateAsync(TKey id, TEntity entity);
    protected abstract Task DeleteAsync(TKey id);
    protected abstract TKey GetId(TEntity entity);
    protected abstract void SetId(TEntity entity, TKey id);

    protected TDestination Map<TDestination>(object source) => mapper.Map<TDestination>(source);
    protected TDestination Map<TDestination>(object source, TDestination destination) =>
        mapper.Map(source, destination);

    protected virtual TEntity CreateEntity(TCreateDto dto) => mapper.Map<TEntity>(dto);
    protected virtual void UpdateEntity(TUpdateDto dto, TEntity entity) => mapper.Map(dto, entity);
    protected virtual void PrepareForCreate(TEntity entity) { }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TResponseDto>>> GetAll()
    {
        var entities = await ListAsync();
        return Ok(mapper.Map<IReadOnlyList<TResponseDto>>(entities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TResponseDto>> GetById(TKey id)
    {
        var entity = await FindAsync(id);
        return entity is null ? NotFound() : Ok(mapper.Map<TResponseDto>(entity));
    }

    [HttpPost]
    public async Task<ActionResult<TResponseDto>> Create(TCreateDto dto)
    {
        var entity = CreateEntity(dto);
        PrepareForCreate(entity);
        var created = await InsertAsync(entity);
        var result = mapper.Map<TResponseDto>(created);
        return CreatedAtAction(nameof(GetById), new { id = GetId(created) }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(TKey id, TUpdateDto dto)
    {
        var existing = await FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        UpdateEntity(dto, existing);
        SetId(existing, id);
        await UpdateAsync(id, existing);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TKey id)
    {
        if (await FindAsync(id) is null)
        {
            return NotFound();
        }

        await DeleteAsync(id);
        return NoContent();
    }
}
