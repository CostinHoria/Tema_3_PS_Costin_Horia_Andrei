using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.Models;
using Tema2_NoLogin.DAL;

namespace Tema2_NoLogin.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SalonContext _context;
        private GenericRepository<User> userRepository;
        private GenericRepository<Service> serviceRepository;
        private GenericRepository<Appointment> appointmentRepository;

        public UnitOfWork(SalonContext context)
        {
            _context = context;
            this.userRepository = new GenericRepository<User>(context);
            this.serviceRepository = new GenericRepository<Service>(context);
            this.appointmentRepository = new GenericRepository<Appointment>(context);

        }

        public GenericRepository<Service> ServiceRepository
        {
            get
            {
                return serviceRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                return userRepository;
            }
        }

        public GenericRepository<Appointment> AppointmentRepository
        {
            get
            {
                return appointmentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
