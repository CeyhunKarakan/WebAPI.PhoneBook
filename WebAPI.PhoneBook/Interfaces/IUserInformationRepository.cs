using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;

namespace WebAPI.PhoneBook.Interfaces
{
   public interface IUserInformationRepository
    {
        public Task<List<UserInformation>> GetAllAsync();
        public Task<List<UserInformation>> GetByIdAsync(int id);
        public Task<UserInformation> CreateAsync(UserInformation userInformation);
        public Task UpdateAsync(UserInformation userInformation);
        public Task RemoveAsync(int id);

    }
}
