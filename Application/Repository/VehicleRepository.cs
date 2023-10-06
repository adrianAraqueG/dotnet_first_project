using Persistence;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    private readonly APIContext _context;
    public VehicleRepository(APIContext context) : base(context){
        _context = context;
    }
}