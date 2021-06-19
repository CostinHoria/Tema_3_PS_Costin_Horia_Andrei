using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Web;
//using System.Web.Mvc;
using Tema2_NoLogin.DAL;
using Tema2_NoLogin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tema2_NoLogin.Services;

namespace Tema2_NoLogin.Controllers
{
    public class ServiceController : Controller
    {
        //private readonly SalonContext _db;
        //private UnitOfWork unitOfWork;
        private ServiceService serviceService;

        public ServiceController(SalonContext db)
        {
            //unitOfWork = new UnitOfWork(db);
            serviceService = new ServiceService(db);

        }
        public IActionResult Index()
        {
            //IEnumerable<Service> objList = _db.Services;
            //IEnumerable<Service> objList = unitOfWork.ServiceRepository.Get();
            IEnumerable<Service> objList = serviceService.getAllServices();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            //_db.Add(service);
            //_db.SaveChanges();
            //unitOfWork.ServiceRepository.Insert(service);
            //unitOfWork.Save();
            serviceService.insertNewService(service);
            return RedirectToAction("index");
        }

        public IActionResult GetForDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var obj = _db.Services.Find(id);

            //var obj = unitOfWork.ServiceRepository.GetByID(id);

            var obj = serviceService.getServiceById(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            //var service = _db.Services.Find(id);

            //var service = unitOfWork.ServiceRepository.GetByID(id);
            var service = serviceService.getServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            //_db.Services.Remove(service);
            //_db.SaveChanges();

            //unitOfWork.ServiceRepository.Delete(service);
            //unitOfWork.Save();
            serviceService.deleteService(service);

            return RedirectToAction("index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var obj = _db.Services.Find(id);

            //var obj = unitOfWork.ServiceRepository.GetByID(id);

            var obj = serviceService.getServiceById(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Service obj)
        {
            if (obj != null)
            {

                //_db.Services.Update(obj);
                //_db.SaveChanges();

                //unitOfWork.ServiceRepository.Update(obj);
                //unitOfWork.Save();

                serviceService.updateService(obj);

                return RedirectToAction("index");
            }
            return View(obj);
        }




        //------------------------------------------------------------------------------------------------------
        //private UnitOfWork unitOfWork = new UnitOfWork();
        /*public IActionResult Index()
        {
            return View();
        }
        public ViewResult Index()
        {
            //var services = unitOfWork.CourseRepository.Get(includeProperties: "Department");
            var services = unitOfWork.ServiceRepository.Get(includeProperties: "Service");
            return View(services.ToList());
        }

        //
        // GET: /Course/Details/5

        public ViewResult Details(int id)
        {
            Service course = unitOfWork.ServiceRepository.GetByID(id);
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Price")]Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.ServiceRepository.Insert(service);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex *///)
        /* {
             //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
             ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
         }
         PopulateDepartmentsDropDownList(service.Id);
         return View(service);
     }

     public ActionResult Edit(int id)
     {
         Service service = unitOfWork.ServiceRepository.GetByID(id);
         PopulateDepartmentsDropDownList(service.Id);
         return View(service);
     }

     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Edit(
          [Bind("Id,Name,Price")]
      Service service)
     {
         try
         {
             if (ModelState.IsValid)
             {
                 unitOfWork.ServiceRepository.Update(service);
                 unitOfWork.Save();
                 return RedirectToAction("Index");
             }
         }
         catch (DataException /* dex *///)
        /*{
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        }
        PopulateDepartmentsDropDownList(service.Id);
        return View(service);
    }

    private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
    {
        var departmentsQuery = unitOfWork.ServiceRepository.Get(
            orderBy: q => q.OrderBy(d => d.Name));
        ViewBag.DepartmentID = new SelectList(departmentsQuery, "Id", "Name", selectedDepartment);
    }*/

        //
        // GET: /Course/Delete/5

        /*public ActionResult Delete(int id)
        {
            Service service = unitOfWork.ServiceRepository.GetByID(id);
            return View(service);
        }*/

        //
        // POST: /Course/Delete/5

        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service course = unitOfWork.ServiceRepository.GetByID(id);
            unitOfWork.ServiceRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }*/
    }
}
