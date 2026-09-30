using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces.Services;

namespace Portfolio.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EducationController(IEducationService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await service.Get(cancellationToken);
        if (result.IsFailure) return NotFound(result);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] EducationDto education, CancellationToken cancellationToken)
    {
        var result = await service.Upsert(education, cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }
}
