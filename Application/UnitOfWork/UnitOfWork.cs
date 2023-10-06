using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly APIContext _context;
    public IUserRepository _users;
    public IVehicleRepository _vehicles;
    public UnitOfWork(APIContext context){
        _context = context;
    }

    
    public IUserRepository Users{
        get{
            if(_users == null){
                return _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public IVehicleRepository Vehicles{
        get{
            if(_vehicles == null){
                return _vehicles = new VehicleRepository(_context);
            }
            return _vehicles;
        }
    }
    /*
    * DEFAULT
    */


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}