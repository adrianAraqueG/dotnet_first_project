using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly APIContext _context;
    public UserRepository(APIContext context): base(context){
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers(){
        return await _context.Set<User>()
                            .Include("Vehicles")
                            .ToListAsync();
    }
}