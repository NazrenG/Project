using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_Model.DTOs
{
    public class DriverDTOs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Bus { get; set; }
        public bool Licence { get; set; }
        public DriverDTOs()
        {

        }
    }
}
