using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarInventory.Core;
using CarInventory.Infrastructure;

namespace CarInventory.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        UsersRepository userRepo;
        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData()
        {
            userRepo = new UsersRepository();
            var result = userRepo.GetUsers();
            Assert.IsNotNull(result);
            var numberOfRecords = result.Count;
            Assert.AreEqual(9, numberOfRecords);
        }
        [TestMethod]
        public void IsRepositoryAddsUser()
        {
            userRepo = new UsersRepository();
            Users user = new Users
            {
                Email = "harshwardhan.dangra@gmail.com",
                Username = "harshwardhan_dangra",
                Password = "harsh123#",
                ContactNumber = "+91-8130989578"
            };
            userRepo.Add(user);
            var result = userRepo.GetUsers();
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(9, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryEditsUser()
        {
            userRepo = new UsersRepository();
            Users user = new Users
            {
                Id = 1,
                Email = "harshwardhan.dangra@gmail.com",
                Username = "harshwardhan.dangra",
                Password = "harsh123#",
                ContactNumber = "+91-8130989578"
            };
            userRepo.Edit(user);
            var result = userRepo.GetUsers();
            Assert.IsNotNull(result);
            var numberofrecords = result.Count;
            Assert.AreEqual(9, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryDeleteUser()
        {
            userRepo = new UsersRepository();
            var result = userRepo.Delete(9);
            Assert.IsNotNull(result);
            var numberofrecords = result;
            Assert.AreEqual(0, numberofrecords);
        }
        [TestMethod]
        public void IsRepositoryUserExists()
        {
            userRepo = new UsersRepository();
            var result = userRepo.UserExists("harshwardhan.dangra@gmail.com");
            Assert.IsNotNull(result);
            var numberofrecords = result;
            Assert.AreEqual(true, numberofrecords);

        }
        [TestMethod]
        public void IsRepositoryUsernameisAvailable()
        {
            userRepo = new UsersRepository();
            var result = userRepo.UsernameisAvailable("harshwardhan+dangra");
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void IsRepositoryVerifiedEmailandActiveUser()
        {
            userRepo = new UsersRepository();
            var result = userRepo.VerifiedEmailandActiveUser(7);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void IsRepositoryLoggedInUser()
        {
            userRepo = new UsersRepository();
            var result = userRepo.LoggedInUser("harshwardhan.dangra@gmail.com", "harsh123#");
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

    }
}
