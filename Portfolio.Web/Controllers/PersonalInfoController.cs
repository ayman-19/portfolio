using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Dtos;
using Portfolio.Web.Interfaces.Services;

namespace Portfolio.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonalInfoController(IPersonalInfoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await service.Get(cancellationToken);
        if (result.IsFailure) return NotFound(result);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] PersonalInfoDto personalInfo, CancellationToken cancellationToken)
    {
        var result = await service.Upsert(personalInfo, cancellationToken);
        if (result.IsFailure) return BadRequest(result);
        return Ok(result);
    }
}
