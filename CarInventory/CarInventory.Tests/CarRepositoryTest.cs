using CarInventory.Core;
using CarInventory.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarInventory.Tests
{
    [TestClass]
    public class CarRepositoryTest
    {
        CarsRepository carRepo;
        CarUserMappingRepository carUserMappingRepository;
        [TestMethod]
        public void IsRepositoryAddCars()
        {
            carRepo = new CarsRepository();
            Core.Car car = new Core.Car
            {
                Brand = "Maruti",
                Model = "2016",
                New = true,
                Price = 97000,
                Year = 2017
            };
            var carid = carRepo.Add(car);
            var result = carRepo.ListofCars(10);
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(10, numberofrecords);
            carUserMappingRepository = new CarUserMappingRepository();
            CarUserMapping carUserMapping = new CarUserMapping
            {
                CarId = carid,
                UserId = 1
            };
            var finalresult = carUserMappingRepository.Add(carUserMapping);
        }
        [TestMethod]
        public void IsRepositoryEditCars()
        {
            carRepo = new CarsRepository();
            Core.Car car = new Core.Car
            {
                Id = 1,
                Brand = "New Maruti",
                Model = "2016",
                New = true,
                Price = 97020,
                Year = 2015
            };
            var carid = carRepo.Edit(car);
            var result = carRepo.ListofCars(10);
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(2, numberofrecords);
            carUserMappingRepository = new CarUserMappingRepository();
            CarUserMapping carUserMapping = new CarUserMapping
            {
                CarId = carid,
                UserId = 1
            };
            var finalresult = carUserMappingRepository.Edit(carUserMapping);
        }
        [TestMethod]
        public void IsRepositoryDeleteCars()
        {
            carUserMappingRepository = new CarUserMappingRepository();
            carUserMappingRepository.Delete(2);
            carRepo = new CarsRepository();
            carRepo.Delete(1);
            var result = carRepo.ListofCars(19);
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(1, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryFindByBrand()
        {
            carRepo = new CarsRepository();
            var result = carRepo.FindByBrand("Maruti");
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(9, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryFindByModel()
        {
            carRepo = new CarsRepository();
            var result = carRepo.FindByModel("2016");
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(10, numberofrecords);

        }
        [TestMethod]
        public void IsRepositoryListofBrands()
        {
            carRepo = new CarsRepository();
            var result = carRepo.ListofBrands();
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(2, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryListofCars()
        {
            carRepo = new CarsRepository();
            var result = carRepo.ListofCars(10);
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(10, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryListofModel()
        {
            carRepo = new CarsRepository();
            var result = carRepo.ListofModel();
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(1, numberofrecords);

        }
    }
}
