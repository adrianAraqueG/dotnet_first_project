using Domain.Entities;

namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IUserRepository Users {get; }
    IVehicleRepository Vehicles {get; }
    Task<int> SaveAsync();
}