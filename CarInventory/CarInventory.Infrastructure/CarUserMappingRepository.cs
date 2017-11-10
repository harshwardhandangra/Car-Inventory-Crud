using CarInventory.Core.Interfaces;
using System.Linq;
using CarInventory.Core;

namespace CarInventory.Infrastructure
{
    public class CarUserMappingRepository : ICarUserMappingRepository
    {
        /// <summary>
        /// Initiliaze Object of Entities
        /// </summary>
        CarsInventoryEntities context = new CarsInventoryEntities();
        /// <summary>
        /// Implementation of Add CarUserMapping
        /// </summary>
        /// <param name="carUserMapping"></param>
        /// <returns></returns>
        public int Add(CarUserMapping carUserMapping)
        {
            var dbCarUserMapping = new Cars_Users_Mapping
            {
                UsersId = carUserMapping.UserId,
                CarsId = carUserMapping.CarId
            };
            context.Cars_Users_Mapping.Add(dbCarUserMapping);
            return context.SaveChanges();
        }
        /// <summary>
        ///  Implementation of Delete CarUserMapping
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var dbCarUserMapping = context.Cars_Users_Mapping.Find(Id);
            context.Cars_Users_Mapping.Remove(dbCarUserMapping);
            return context.SaveChanges();
        }
        /// <summary>
        ///  Implementation of Edit CarUserMapping
        /// </summary>
        /// <param name="carUserMapping"></param>
        /// <returns></returns>
        public int Edit(CarUserMapping carUserMapping)
        {
            var dbCarUserMapping = context.Cars_Users_Mapping.Where(cu => cu.CarsId == carUserMapping.CarId && cu.UsersId == carUserMapping.UserId).FirstOrDefault();
            dbCarUserMapping.UsersId = carUserMapping.UserId;
            dbCarUserMapping.CarsId = carUserMapping.CarId;
            return context.SaveChanges();
        }
    }
}
