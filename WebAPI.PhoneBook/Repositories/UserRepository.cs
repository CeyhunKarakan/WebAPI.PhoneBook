using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;
using WebAPI.PhoneBook.Interfaces;

namespace WebAPI.PhoneBook.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository (UserContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UUID == id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _context.Users.FindAsync(id);
            _context.Users.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var unchangedEntity = await _context.Users.FindAsync(user.UUID);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
    }
}
