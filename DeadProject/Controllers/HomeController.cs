using DeadProject.AppControllers;
using System.Web.Mvc;
using DeadEntity.IRepository;

namespace DeadProject.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(CurentUser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}