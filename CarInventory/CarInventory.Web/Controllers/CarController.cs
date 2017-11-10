using CarInventory.Core;
using CarInventory.Infrastructure;
using System;
using System.Collections;
using System.Web.Mvc;

namespace CarInventory.Web.Controllers
{
    public class CarController : Controller
    {
        /// <summary>
        /// Implementation of Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            var userRepo = new UsersRepository();
            int user = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(Session["email"])))
                user = userRepo.GetUserFromEmail(Convert.ToString(Session["email"]));
            var carRepo = new CarsRepository();
            var model = carRepo.ListofCars(user);
            return View(model);

        }
        /// <summary>
        /// Implementation of Create
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Create()
        {
            return PartialView();
        }
        /// <summary>
        /// Implementation of Index POST
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Core.Car obj)
        {
            if (obj.Id == 0)
            {
                var userRepo = new UsersRepository();
                var user = userRepo.GetUserFromEmail(Convert.ToString(Session["email"]));
                var carRepo = new CarsRepository();
                var carid = carRepo.Add(obj);
                var caruserRepo = new CarUserMappingRepository();
                var caruserMapping = new CarUserMapping
                {
                    CarId = carid,
                    UserId = user
                };
                caruserRepo.Add(caruserMapping);
                var model = carRepo.ListofCars(user);
                return View(model);
            }
            else
            {
                var userRepo = new UsersRepository();
                var user = userRepo.GetUserFromEmail(Convert.ToString(Session["email"]));
                var carRepo = new CarsRepository();
                var carid = carRepo.Edit(obj);
                var caruserRepo = new CarUserMappingRepository();
                var caruserMapping = new CarUserMapping
                {
                    CarId = carid,
                    UserId = user
                };
                caruserRepo.Edit(caruserMapping);
                var model = carRepo.ListofCars(user);
                return View(model);
            }

        }
        /// <summary>
        /// Implementation of Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var carRepo = new CarsRepository();
            var model = carRepo.FindCarById(id);
            return View(model);
        }
    }
}