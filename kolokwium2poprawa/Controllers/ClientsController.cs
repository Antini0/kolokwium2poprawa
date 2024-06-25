using kolokwium2poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2poprawa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IDbService _dbService;
    public ClientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientsInfo(int clientId)
    {
        var result = await _dbService.GetClientsData(clientId);

        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
}