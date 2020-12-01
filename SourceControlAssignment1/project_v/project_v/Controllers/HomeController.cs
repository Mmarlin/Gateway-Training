using System.Web.Mvc;
using project_v.Models;
namespace project_v.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentDetails(StudentModel sm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.name = sm.Name;
                ViewBag.email = sm.Email;
                ViewBag.age = sm.Age;
                return View("Index");
            }
            else
            {
                ViewBag.name = "No Data";
                ViewBag.email = "No Data";
                ViewBag.age = "No Data";
                return View("Index");
            }
        }
    }
}