using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.PhoneBook.Data
{
    public class UserInformationContext : DbContext
    {
        public UserInformationContext(DbContextOptions<UserInformationContext> options) : base(options)
        {

        }
        public DbSet<UserInformation> UserInformations { get; set; }

    }
}
