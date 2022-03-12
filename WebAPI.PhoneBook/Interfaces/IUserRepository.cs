using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;

namespace WebAPI.PhoneBook.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<User> CreateAsync(User user);
        public Task UpdateAsync(User user);
        public Task RemoveAsync(int id);
    }
}
