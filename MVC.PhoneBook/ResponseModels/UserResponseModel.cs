using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.PhoneBook.ResponseModels
{
    public class UserResponseModel
    {
        public int UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Location { get; set; }
    }
}
