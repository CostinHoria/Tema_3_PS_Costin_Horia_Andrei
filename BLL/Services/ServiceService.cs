using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;

namespace Tema2_NoLogin.Services
{
    public class ServiceService
    {
        private UnitOfWork unitOfWork;
        public ServiceService(SalonContext db)
        {
            unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<Service> getAllServices()
        {
            IEnumerable<Service> services = unitOfWork.ServiceRepository.Get();
            return services;
        }

        public void insertNewService(Service service)
        {
            unitOfWork.ServiceRepository.Insert(service);
            unitOfWork.Save();
        }

        public Service getServiceById(int? id)
        {
            Service service = unitOfWork.ServiceRepository.GetByID(id);
            return service;
        }

        public void deleteService(Service service)
        {
            unitOfWork.ServiceRepository.Delete(service);
            unitOfWork.Save();
        }

        public void updateService(Service service)
        {
            unitOfWork.ServiceRepository.Update(service);
            unitOfWork.Save();
        }
    }
}
