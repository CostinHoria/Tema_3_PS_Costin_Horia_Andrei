using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tema2_NoLogin.Models
{
    [Table("service")]
    public class Service
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
    }
}
