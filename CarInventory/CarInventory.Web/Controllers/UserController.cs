using CarInventory.Core;
using CarInventory.Infrastructure;
using CarInventory.Web.Utilites;
using System;
using System.Web.Mvc;

namespace CarInventory.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        ///  Implementation of Login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            Log.Info("Login Page Started...");
            return View();
        }
        /// <summary>
        ///  Implementation of Register
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            Log.Info("Register Page Started...");
            return View();
        }
        /// <summary>
        ///  Implementation of Login POST
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Users obj)
        {
            try
            {
                var email = obj.Email;
                var password = obj.Password;
                UsersRepository usersRepo = new UsersRepository();
                var userlogeedin = usersRepo.LoggedInUser(email, password);
                Session["email"] = email;
                ViewBag.UserStatus = userlogeedin;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return View();
        }
        /// <summary>
        ///  Implementation of Register POST
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(Users obj)
        {
            try
            {
                UsersRepository usersRepo = new UsersRepository();
                var userId = usersRepo.Add(obj);
                SendMail.VerificationMailSend(obj.Email);
                ViewBag.UserId = userId;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return View();
        }
        /// <summary>
        ///  Implementation of Verify
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public ActionResult Verify(string q)
        {
            try
            {
                var mail = CryptoEngine.Decrypt(q);
                UsersRepository usersRepo = new UsersRepository();
                var userid = usersRepo.GetUserFromEmail(mail);
                var result = usersRepo.VerifiedEmailandActiveUser(userid);
                if (result == 1)
                {
                    RedirectToAction("Index", "Car");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return View();
        }

    }
}