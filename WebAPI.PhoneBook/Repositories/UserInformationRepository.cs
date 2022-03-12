using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.PhoneBook.Data;
using WebAPI.PhoneBook.Interfaces;

namespace WebAPI.PhoneBook.Repositories
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly UserInformationContext _userInformationContext;

        public UserInformationRepository(UserInformationContext userInformationContext)
        {
            _userInformationContext = userInformationContext;
        }

        public async Task<UserInformation> CreateAsync(UserInformation userInformation)
        {
            await _userInformationContext.UserInformations.AddAsync(userInformation);
            await _userInformationContext.SaveChangesAsync();

            return userInformation;
        }

        public async Task<List<UserInformation>> GetAllAsync()
        {
            return await _userInformationContext.UserInformations.ToListAsync();
        }

        public async Task<List<UserInformation>> GetByIdAsync(int id)
        {
            return await _userInformationContext.UserInformations.Where(x => x.UUID == id).ToListAsync();  
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _userInformationContext.UserInformations.FindAsync(id);
            _userInformationContext.UserInformations.Remove(removedEntity);
            await _userInformationContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserInformation userInformation)
        {
            var unchangedEntity = await _userInformationContext.UserInformations.FindAsync(userInformation.UInfoID);
            _userInformationContext.Entry(unchangedEntity).CurrentValues.SetValues(userInformation);
            await _userInformationContext.SaveChangesAsync();
        }
    }
}
