using System.Collections;

namespace CarInventory.Core.Interfaces
{
    public interface ICarsRepository
    {
        /// <summary>
        /// Declaration of Method Add Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        int Add(Car car);
        /// <summary>
        /// Declaration of Method Edit Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        int Edit(Car car);
        /// <summary>
        /// Declaration of Method Delete Car
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);
        /// <summary>
        /// Declaration of Method List of Car by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList ListofCars(int userId);
        /// <summary>
        /// Declaration of Method Find By Brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        IList FindByBrand(string brand);
        /// <summary>
        /// Declaration of Method Find By Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IList FindByModel(string model);
        /// <summary>
        /// Declaration of Method List Of Brands
        /// </summary>
        /// <returns></returns>
        IList ListofBrands();
        /// <summary>
        /// Declaration of Method List Of Model
        /// </summary>
        /// <returns></returns>
        IList ListofModel();
        /// <summary>
        /// Declaration of Method Find Car By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Car FindCarById(int id);
    }
}
