using CarInventory.Core.Interfaces;
using System.Linq;
using CarInventory.Core;
using System.Collections;

namespace CarInventory.Infrastructure
{
    public class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// Initiliaze Object of Entities
        /// </summary>
        CarsInventoryEntities context = new CarsInventoryEntities();
        /// <summary>
        /// Implementation of Add User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(Users user)
        {
            var dbUser = new User
            {
                Email = user.Email,
                ContactNumber = user.ContactNumber,
                IsEmailVerified = false,
                IsActive = false,
                Password = user.Password,
                Username = user.Username
            };
            context.Users.Add(dbUser);
            context.SaveChanges();
            return dbUser.Id;
        }
        /// <summary>
        /// Implementation of Delete User
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            var dbUser = context.Users.Find(Id);
            if (dbUser != null)
                context.Users.Remove(dbUser);
            return context.SaveChanges();
        }
        /// <summary>
        /// Implementation of Edit User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Edit(Users user)
        {
            var dbUser = context.Users.Find(user.Id);
            dbUser.Email = user.Email;
            dbUser.ContactNumber = user.ContactNumber;
            dbUser.IsEmailVerified = user.IsEmailVerified;
            dbUser.IsActive = user.IsActive;
            dbUser.Password = user.Password;
            dbUser.Username = user.Username;
            context.SaveChanges();
            return dbUser.Id;
        }
        /// <summary>
        /// Implementation of Get User from Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int GetUserFromEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefault().Id;
        }
        /// <summary>
        /// Implementation of Get Users
        /// </summary>
        /// <returns></returns>
        public IList GetUsers()
        {
            return context.Users.ToList();
        }
        /// <summary>
        /// Implementation of LoggedInUser
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoggedInUser(string email, string password)
        {
            var dbUser = context.Users.Where(u => (u.Email == email && u.Password == password) || (u.Username == email && u.Password == password)).FirstOrDefault();
            if (dbUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Implementation of User Exits
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool UserExists(string email)
        {
            var dbUser = context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (dbUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Implementation of User Name Available
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UsernameisAvailable(string username)
        {
            var dbUser = context.Users.Where(u => u.Username == username).FirstOrDefault();
            if (dbUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Implementation of Verified Email and Active User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int VerifiedEmailandActiveUser(int id)
        {
            var dbUser = context.Users.Find(id);
            dbUser.IsEmailVerified = true;
            dbUser.IsActive = true;
            return context.SaveChanges();
        }
    }
}
