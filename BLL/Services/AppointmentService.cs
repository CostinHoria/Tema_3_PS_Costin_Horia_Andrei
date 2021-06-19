using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;

namespace Tema2_NoLogin.Services
{
    public class AppointmentService
    {
        private UnitOfWork unitOfWork;
        //private Appointment appointment1;
        public AppointmentService(SalonContext db)
        {
            unitOfWork = new UnitOfWork(db);
            //appointment1 = new Appointment();
        }

        public IEnumerable<Appointment> getAllAppointments()
        {
            IEnumerable<Appointment> services = unitOfWork.AppointmentRepository.Get();
            return services;
        }

        public void insertNewAppointment(Appointment appointment1)
        {
            //calculateTotal(appointment);
            //appointment = new Appointment();
            //bool ok = this.checkAppointmentsForDuplicates(appointment1);
            //if (ok == true)
            //{
                unitOfWork.AppointmentRepository.Insert(appointment1);
                unitOfWork.Save();
            //}
        }

        public Appointment getAppointmentById(int? id)
        {
            Appointment appointment = unitOfWork.AppointmentRepository.GetByID(id);
            return appointment;
        }

        public void calculateTotal(Appointment appointment)
        {
            double total = 0.0f;
            foreach (Service service in appointment.Services)
            {
                total += service.Price;
            }
            Console.WriteLine(total);

            appointment.Total = total;
        }

        public void addServiceToAppointment(Appointment appointment, String nameService)
        {
            List<Service> services = (List<Service>)unitOfWork.ServiceRepository.Get();

            Service result = services.Find(x => x.Name == nameService);
            if(result != null)
            {
                System.Console.WriteLine("DA");
                appointment.Services.Add(result);
            }
            //List<Service> list = appointment.Services;
            Console.WriteLine(result.Name+result.Price);
            //list.Add(result);
            
            //appointment.Services = list;
        }

        public void updateAppointment(Appointment appointment)
        {
            unitOfWork.AppointmentRepository.Update(appointment);
            unitOfWork.Save();
        }

        public IEnumerable<Appointment> getAppointmentsByClientName(String name)
        {
            //name = "Andreea";
            List<Appointment> services = (List<Appointment>)unitOfWork.AppointmentRepository.Get();
            IEnumerable<Appointment> appointments = services.FindAll(x => x.Name_client.Equals(name));
            return appointments;
        }


        public bool checkAppointmentsForDuplicates(Appointment appointment)
        {
            bool ok = true;
            foreach (Appointment app in unitOfWork.AppointmentRepository.Get())
            {
                if ((app.Appointment_date.Day == appointment.Appointment_date.Day) &&
                    (app.Appointment_date.Month == appointment.Appointment_date.Month) &&
                    (app.Appointment_date.Year == appointment.Appointment_date.Year) &&
                    (app.Appointment_date.Hour == appointment.Appointment_date.Hour) &&
                    (app.Appointment_date.Minute == appointment.Appointment_date.Minute))
                {
                    foreach (Service ser_j in appointment.Services)
                    {
                        if (app.AppointmentAsString.Contains(ser_j.Name) == true)
                        {
                            ok = false;
                        }
                    }
                }
            }
            return ok;
        }

        public List<Appointment> getAllAppointmentsByDay(int day)
        {
            List<Appointment> apps_list = new List<Appointment>();
            foreach (Appointment app in unitOfWork.AppointmentRepository.Get())
            {
                if (app.Appointment_date.Day == day)
                    apps_list.Add(app);
            }
            return apps_list;
        }


        public List<Appointment> getAppointmentsBetweenTwoDates(DateTime firstDate, DateTime lastDate)
        {
            //firstDate = new DateTime(2021,1,1);
            //lastDate = new DateTime(2021, 7, 7);
            List<Appointment> apps_list = new List<Appointment>();
            foreach (Appointment app in unitOfWork.AppointmentRepository.Get())
            {
                if (DateTime.Compare(app.Appointment_date, firstDate) > 0 && DateTime.Compare(app.Appointment_date, lastDate) < 0)
                    apps_list.Add(app);
            }

            return apps_list;
        }


    }
}
