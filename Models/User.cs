using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tema2_NoLogin.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
    }
}
