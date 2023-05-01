using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers;

public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    
    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }
}
