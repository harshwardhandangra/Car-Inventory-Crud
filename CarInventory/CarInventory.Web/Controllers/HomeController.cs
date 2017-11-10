using CarInventory.Web.Utilites;
using System.Web.Mvc;

namespace CarInventory.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Implementation of Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Log.Info("Home Page Started...");
            return View();
        }
    }
}