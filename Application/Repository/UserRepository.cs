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
}