using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DashboardController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(DashboardController));

        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["email"] != null)
            {
                logger.Info("Logged In through Session");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}