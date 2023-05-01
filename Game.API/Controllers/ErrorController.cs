using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : ControllerBase
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Error()
    {
        _logger.LogError("An internal server error has occured.");
        return Problem(title: "Internal Server Error", detail: "An internal server error has occured.");
    }
}
