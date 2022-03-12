using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.PhoneBook.ResponseModels
{
    public class UserInformationResponseModel
    {
        public int UInfoID { get; set; }
        public int UUID { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Location { get; set; }
    }
}
