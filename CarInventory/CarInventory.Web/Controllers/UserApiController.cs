using CarInventory.Infrastructure;
using System.Web.Http;

namespace CarInventory.Web.Controllers
{
    public class UserApiController : ApiController
    {
        /// <summary>
        /// Implementation of User Name Exits API
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Route("api/user/usernameexits")]
        [HttpPost, HttpGet]
        public bool UsernameExits(string username)
        {
            var userRepo = new UsersRepository();
            return userRepo.UsernameisAvailable(username);
        }
        /// <summary>
        ///  Implementation of Email Exits API
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Route("api/user/emailexits")]
        [HttpPost, HttpGet]
        public bool EmailExists(string email)
        {
            var userRepo = new UsersRepository();
            return userRepo.UserExists(email);
        }
    }
}
