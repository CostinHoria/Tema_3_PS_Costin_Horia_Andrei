using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.Models;
using CsvHelper;
using ServiceStack.Text;



namespace Tema2_NoLogin.BLL.Factory
{
    public class CsvExporter : Exporter
    {
        public override string getData(List<Appointment> appointments)
        {
            string output = CsvSerializer.SerializeToCsv(appointments);
            return output;
        }
    }
}
