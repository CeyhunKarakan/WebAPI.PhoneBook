using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.PhoneBook.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base (options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInformation>().HasData(new UserInformation[]
            {
                new(){UInfoID=1,UUID=1, Mail="ck@ck.com", Phone="777888", Location="TURKEY"},
                new(){UInfoID=2,UUID=2, Mail="ck@ck.com", Phone="777888", Location="USA"}
            });
            modelBuilder.Entity<User>().HasData(new User[]{
            new() {UUID=1, Name="John", Surname="Doe", Company="Amazon"},
            new() {UUID=2, Name="Ricky", Surname="More", Company="Amazon"}
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
    }
}
