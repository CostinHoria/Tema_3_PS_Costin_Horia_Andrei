using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema2_NoLogin.BLL.Factory
{
    public class ExporterFactory
    {
        public Exporter GetExporter(string type)
        {
            Exporter exporter = null;
            if (type.Equals("csv"))
            {
                exporter = new CsvExporter();
            }
            else if (type.Equals("json"))
            {
                exporter = new JsonExporter();
            }
            return exporter;
        }
    }
}
