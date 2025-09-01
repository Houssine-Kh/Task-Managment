using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveAsync(User user)
        {
            if (_context.Users.Any(u => u.Id == user.Id))
            {
                _context.Users.Update(user);
            }
            else
            {
                await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();
        }
    }
}
