using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces.Services;

namespace Portfolio.Web.Controllers;

[ApiController, Route("api/[controller]")]
public class ExperienceController(IExperienceService service) : ControllerBase
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
    public async Task<IActionResult> Add([FromBody] ExperienceDto experience, CancellationToken cancellationToken)
    {
        var result = await service.Add(experience, cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] ExperienceDto experience, CancellationToken cancellationToken)
    {
        experience.Id = id;
        var result = await service.Update(experience, cancellationToken);
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
