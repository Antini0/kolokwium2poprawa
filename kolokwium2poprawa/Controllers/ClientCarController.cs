using kolokwium2poprawa.Models;
using kolokwium2poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2poprawa.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientCarController : ControllerBase
{
    private readonly IDbService _dbService;
    public ClientCarController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    [Route("/api/clients")]
    public async Task<IActionResult> AddClientWithRental([FromBody] AddClientWithRentalRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid request payload.");
        }

        bool carExists = await _dbService.DoesCarExist(request.CarId);
        if (!carExists)
        {
            return NotFound("Car does not exist.");
        }

        var client = new Client
        {
            FirstName = request.Client.FirstName,
            LastName = request.Client.LastName,
            Adress = request.Client.Address
        };
        await _dbService.AddNewClient(client);

        var totalDays = (request.DateTo - request.DateFrom).Days;
        var car = await _dbService.GetCarById(request.CarId);
        var totalPrice = totalDays * car.PricePerDay;

        var carRental = new Car_Rental
        {
            IdClient = client.IdClient,
            IdCar = request.CarId,
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            TotalPrice = totalPrice,
            Disscount = request.Discount
        };
        await _dbService.AddCarRental(carRental);

        return Ok("Client and car rental added successfully.");
    }
}

public class AddClientWithRentalRequest
{
    public ClientRequest Client { get; set; }
    public int CarId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int Discount { get; set; }
}

public class ClientRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}