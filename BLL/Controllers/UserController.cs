using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;
using Tema2_NoLogin.Services;

namespace Tema2_NoLogin.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController (SalonContext db)
        {
            userService = new UserService(db);
        }
        public IActionResult Index()
        {
            IEnumerable<User> objList = userService.getAllUsers();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            //_db.Add(user);
            //_db.SaveChanges();
            userService.insertNewUser(user);
            return RedirectToAction("index");
        }

        public IActionResult GetForDelete(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            //var obj = _db.Users.Find(id);
            var obj = userService.getUserById(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var user = userService.getUserById(id); //_db.Users.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            //_db.Users.Remove(user);
            //_db.SaveChanges();
            userService.deleteUser(user);

            return RedirectToAction("index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = userService.getUserById(id); //_db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(User obj)
        {
            if (obj != null)
            {
                //_db.Users.Update(obj);
                //_db.SaveChanges();
                userService.updateUser(obj);
                return RedirectToAction("index");
            }
            return View(obj);
        }
    }
}
