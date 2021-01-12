using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            //Checking Login Session
            if (Session["email"] != null)
            {
                //Redirecting to Dashboard
                logger.Info("Logged In through Session");
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Index(mvcLoginModel lgn)
        {
            IEnumerable<mvcLoginModel> userList;
            try
            {
                //Getting Users from database using web api
                HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Login").Result;
                userList = response.Content.ReadAsAsync<IEnumerable<mvcLoginModel>>().Result;
                //matching login cred with database using web api
                var stat = userList.Where(m => m.EMAIL == lgn.EMAIL && m.PASSWORD == lgn.PASSWORD).FirstOrDefault();
                if (stat != null)
                {
                    Session["email"] = lgn.EMAIL;
                    TempData["msg"] = "Login Successfully";
                    logger.Info("Login Successfully");
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception - " + e.ToString());
            }
            TempData["msg"] = "Check Your Email and Password.";
            return View("Index");
        }

        public ActionResult Logout()
        {
            //Removing login session
            Session["email"] = null;
            logger.Info("Logged Out Successfully");
            return RedirectToAction("Index", "Home");
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