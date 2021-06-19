using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema2_NoLogin.Views.Models
{
    public class ViewModel
    {
        public string ClientName { get; set; }
        public List<Tema2_NoLogin.Models.Appointment> Appointements { get; set; }
    }
}
