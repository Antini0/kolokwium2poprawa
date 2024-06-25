using kolokwium2poprawa.Data;
using kolokwium2poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2poprawa.Services;

public class DbService : IDbService
{
    private readonly myContext _myContext;
    public DbService(myContext myContext)
    {
        _myContext = myContext;
    }

    public async Task<Client> GetClientsData(int clientId)
    {
        return await _myContext.Clients.Where(c => c.IdClient == clientId).FirstOrDefaultAsync();
    }

    public async Task<bool> DoesCarExist(int carId)
    {
        return await _myContext.Cars.AnyAsync(c => c.IdCar == carId);
    }

    public Task<int> GetRentingPrice(int CarRentalId)
    {
        var carRental = _myContext.CarRentals.Where(cr => cr.IdCar_Rental == CarRentalId);
        return Task.FromResult(100); 
    }

    public async Task AddNewClient(Client client)
    {
        await _myContext.AddAsync(client);
        await _myContext.SaveChangesAsync();
    }

    public async Task AddCarRental(Car_Rental carRental)
    {
        await _myContext.CarRentals.AddAsync(carRental);
        await _myContext.SaveChangesAsync();
    }

    public async Task<Car> GetCarById(int carId)
    {
        return await _myContext.Cars.FindAsync(carId);
    }
}