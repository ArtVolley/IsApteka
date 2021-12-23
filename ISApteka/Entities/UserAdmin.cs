using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISApteka.Entities.Enums;

namespace ISApteka.Entities
{
    public class UserAdmin
    {
        public int Id  { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }
    }
}
