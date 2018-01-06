using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicapCalculator.Models
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int MyProperty { get; set; }
        public string Role { get; set; }
    }
}
