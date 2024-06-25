using kolokwium2poprawa.Models;

namespace kolokwium2poprawa.Services;

public interface IDbService
{
    Task<Client> GetClientsData(int clientId);
    Task<bool> DoesCarExist(int carId);
    Task<int> GetRentingPrice(int CarRentalId);
    Task AddNewClient(Client client);
    Task AddCarRental(Car_Rental carRental);

    Task<Car> GetCarById(int carId);
}