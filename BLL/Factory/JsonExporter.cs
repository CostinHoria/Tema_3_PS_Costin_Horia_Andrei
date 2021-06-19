using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.Models;
using System.Text.Json;


namespace Tema2_NoLogin.BLL.Factory
{
    public class JsonExporter : Exporter
    {

        public override string getData(List<Appointment> appointments)
        {
            //JsonSerializer jsonSerializer = new JsonSerializer();
            var indented = new JsonSerializerOptions { WriteIndented = true };
            string output = JsonSerializer.Serialize(appointments,indented);
            return output;
        }
    }
}
