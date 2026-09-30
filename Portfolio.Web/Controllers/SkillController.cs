using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces.Services;

namespace Portfolio.Web.Controllers;

[ApiController, Route("api/[controller]")]
public class SkillController(ISkillService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await service.GetList(cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await service.GetById(id, cancellationToken);
        if (result.IsFailure) return NotFound(result);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SkillDto skill, CancellationToken cancellationToken)
    {
        var result = await service.Add(skill, cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] SkillDto skill, CancellationToken cancellationToken)
    {
        skill.Id = id;
        var result = await service.Update(skill, cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var result = await service.Delete(id, cancellationToken);
        if (result.IsFailure) return NotFound(result);
        return Ok(result);
    }
}
