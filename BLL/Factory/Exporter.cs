using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.Models;

namespace Tema2_NoLogin.BLL.Factory
{
    public abstract class Exporter
    {
        //public abstract Exporter createExporter();
        public abstract string getData(List<Appointment> appointments);
    }
}
