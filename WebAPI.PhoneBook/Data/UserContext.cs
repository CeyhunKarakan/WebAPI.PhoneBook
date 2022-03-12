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
            modelBuilder.Entity<User>().HasData(new User[]{
            new() {UUID=1, Name="John", Surname="Doe", Company="Amazon", Phone="111444", Mail="joh.doe@amazon.com",Location="USA"},
            new() {UUID=2, Name="Ricky", Surname="More", Company="Amazon", Phone="777888", Mail="ricky.more@amazon.com",Location="USA"}
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
