using Domain.Entities;

namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IUserRepository Users {get; }
    IUserRepository Vehicles {get; }
    Task<int> SaveAsync();
}