namespace CarInventory.Core.Interfaces
{
    public interface ICarUserMappingRepository
    {
        /// <summary>
        /// Declaration of Method Add Car User Mapping
        /// </summary>
        /// <param name="carUserMapping"></param>
        /// <returns></returns>
        int Add(CarUserMapping carUserMapping);
        /// <summary>
        /// Declaration of Method Edit Car User Mapping
        /// </summary>
        /// <param name="carUserMapping"></param>
        /// <returns></returns>
        int Edit(CarUserMapping carUserMapping);
        /// <summary>
        /// Declaration of Method Delete Car User Mapping
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);
    }
}
