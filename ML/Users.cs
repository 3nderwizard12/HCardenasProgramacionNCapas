using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class User
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PotalCode { get; set; }
        public string UserName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string CURP { get; set; }
        public string Image { get; set; }

        public ML.Role Role { get; set; }

        public List<object> Users { get; set; }
    }

}
