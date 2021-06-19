using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;

namespace Tema2_NoLogin.Services
{
    public class UserService
    {
        private UnitOfWork unitOfWork;
        public UserService(SalonContext db)
        {
            unitOfWork = new UnitOfWork(db);
        }

        public IEnumerable<User> getAllUsers()
        {
            IEnumerable<User> users = unitOfWork.UserRepository.Get();
            return users;
        }

        public void insertNewUser(User user)
        {
            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
        }

        public User getUserById(int? id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            return user;
        }

        public void deleteUser(User user)
        {
            unitOfWork.UserRepository.Delete(user);
            unitOfWork.Save();
        }

        public void updateUser(User user)
        {
            unitOfWork.UserRepository.Update(user);
            unitOfWork.Save();
        }
    }
}
