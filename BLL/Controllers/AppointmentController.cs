using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Tema2_NoLogin.Services;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;
using Tema2_NoLogin.BLL.Factory;

namespace Tema2_NoLogin.Controllers
{
    public class AppointmentController : Controller
    {
        public AppointmentService appointmentService;
        public Appointment appointment1;

        public AppointmentController(SalonContext db)
        {
            appointmentService = new AppointmentService(db);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Appointment> objList = appointmentService.getAllAppointments();

            return View(objList);
        }

        /*public IActionResult AppointmentsByClient()
        {
            return View();
        }*/
            
        [HttpGet]
        public IActionResult AppointmentsByClient(String name_Client)
        {
            //name_Client = "Diana";
            var appointments = appointmentService.getAppointmentsByClientName(name_Client);
            Console.WriteLine(name_Client);
            return View(appointments);
        }
        //[HttpGet]
        public IActionResult AppointmentsByDay(int day)
        {
            day = 6;
            var appointments = appointmentService.getAllAppointmentsByDay(day);
            return View(appointments);
        }
        /*public IActionResult AppointmentsBetweenTwoDates()
        {
            return View();
        }*/

        //[HttpPost]
        public IActionResult AppointmentsBetweenTwoDates(String first_Date, String last_Date)
        {
            DateTime firstDate = DateTime.Parse("01/01/2021");
            DateTime lastDate = DateTime.Parse("07/07/2021");
            var appointments = appointmentService.getAppointmentsBetweenTwoDates(firstDate,lastDate);
            return View(appointments);
            //return RedirectToAction("index");
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment appointment)
        {
            appointment1 = appointment;
            appointment1.Services = new List<Service>();
            appointmentService.insertNewAppointment(appointment1);
            //appointmentService.getAppointmentsBetweenTwoDates(new DateTime(2021,1,1),new DateTime(2021,7,7));
            return RedirectToAction("index");
        }

        public IActionResult AddService(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var obj = _db.Services.Find(id);

            //var obj = unitOfWork.ServiceRepository.GetByID(id);

            var obj = appointmentService.getAppointmentById(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddService(Appointment appointment, String serviceName)
        {
            //Appointment appointment = appointmentService.getAppointmentById(Id);
            if (appointment != null)
            {
                appointment1 = appointment;
                appointmentService.addServiceToAppointment(appointment1, serviceName);
                appointmentService.calculateTotal(appointment1);
                appointment1.AppointmentAsString = appointment1.ServicesToString();
                appointmentService.updateAppointment(appointment1);

               return RedirectToAction("index");
            }
            return View(appointment1);
        }

        public string Par(string name, DateTime dateTime)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, datetime is: {dateTime}");
        }

        public ActionResult Download()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Download(String typeDoc, DateTime first_Date, DateTime last_Date)
        {
            //typeDoc = "csv";
            ExporterFactory exporterFactory = new ExporterFactory();
            Exporter exporter = exporterFactory.GetExporter(typeDoc);

            //DateTime first_Date = DateTime.Parse(firstDate);
            //DateTime last_Date = DateTime.Parse(lastDate);
            var fileName = "Report" + DateTime.Now.ToString() + "."+typeDoc;
            var data = exporter.getData((List<Appointment>)appointmentService.getAppointmentsBetweenTwoDates(first_Date,last_Date));
            return File(new System.Text.UTF8Encoding().GetBytes(data), "text/"+typeDoc, fileName);
        }
    }
}
