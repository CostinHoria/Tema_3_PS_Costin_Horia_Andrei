using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_NoLogin.Models
{
    [Table("appointment")]
    public class Appointment
    {
        public int Id { get; set; }
        public String Name_client { get; set; }
        public String Phone_number { get; set; }
        //[DataType(DataType.Date)]
        public DateTime Appointment_date { get; set; }
        public double Total { get; set; }
        public List<Service> Services { get; set; }

        public string AppointmentAsString { get; set; }

        public Appointment()
        {
            Services = new List<Service>();
        }

        public String ServicesToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Service service in Services)
            {
                stringBuilder.Append(service.Name + " ,");
            }
            return stringBuilder.ToString();
        }
    }
}
