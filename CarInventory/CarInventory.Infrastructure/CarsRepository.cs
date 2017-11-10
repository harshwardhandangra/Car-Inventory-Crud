using CarInventory.Core.Interfaces;
using System.Linq;
using System.Collections;
using CarInventory.Core;

namespace CarInventory.Infrastructure
{
    public class CarsRepository : ICarsRepository
    {
        /// <summary>
        /// Initiliaze Object of Entities
        /// </summary>
        CarsInventoryEntities context = new CarsInventoryEntities();
        /// <summary>
        /// Implementation of Add Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int Add(Core.Car car)
        {

            var dbCar = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                New = car.New,
                Price = car.Price,
                Year = car.Year
            };
            context.Cars.Add(dbCar);
            context.SaveChanges();
            return dbCar.Id;
        }
        /// <summary>
        ///  Implementation of Delete Car
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var dbCar = context.Cars.Find(Id);
            context.Cars.Remove(dbCar);
            return context.SaveChanges();
        }
        /// <summary>
        ///  Implementation of Edit Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public int Edit(Core.Car car)
        {
            var dbCar = context.Cars.Find(car.Id);
            dbCar.Brand = car.Brand;
            dbCar.Model = car.Model;
            dbCar.New = car.New;
            dbCar.Price = car.Price;
            dbCar.Year = car.Year;
            context.SaveChanges();
            return dbCar.Id;
        }
        /// <summary>
        ///  Implementation of Find By Brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public IList FindByBrand(string brand)
        {
            var dbcars = context.Cars.Where(c => c.Brand == brand);
            return dbcars.ToList();
        }
        /// <summary>
        ///  Implementation of Find By Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IList FindByModel(string model)
        {
            var dbcars = context.Cars.Where(c => c.Model == model);
            return dbcars.ToList();
        }
        /// <summary>
        ///  Implementation of Find Car By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Core.Car FindCarById(int id)
        {
            var dbCars = context.Cars.Find(id);
            var car = new Core.Car
            {
                Id = dbCars.Id,
                Brand = dbCars.Brand,
                Model = dbCars.Model,
                New = dbCars.New,
                Price = dbCars.Price,
                Year = dbCars.Year
            };
            return car;
        }
        /// <summary>
        ///  Implementation of List of Brands
        /// </summary>
        /// <returns></returns>
        public IList ListofBrands()
        {
            return context.Cars.GroupBy(c => c.Brand).ToList();
        }
        /// <summary>
        ///  Implementation of List of Car
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList ListofCars(int userId)
        {
            var dbCarsList = from car in context.Cars
                             join caruser in context.Cars_Users_Mapping on car.Id equals caruser.CarsId
                             where caruser.UsersId == userId
                             select new Core.Car
                             {
                                 Id = car.Id,
                                 Brand = car.Brand,
                                 Model = car.Model,
                                 New = car.New,
                                 Price = car.Price,
                                 Year = car.Year
                             };
            return dbCarsList.ToList();
        }
        /// <summary>
        ///  Implementation of List of Model
        /// </summary>
        /// <returns></returns>
        public IList ListofModel()
        {
            return context.Cars.GroupBy(c => c.Model).ToList();
        }
    }
}
