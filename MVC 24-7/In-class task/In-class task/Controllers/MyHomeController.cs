using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace In_class_task.Controllers
{
    public class MyHomeController : Controller
    {
        // GET: MyHome
        public ActionResult Index()
        {
            Session["IsLoggedIn"] = "false";

            return View();
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            string fName = form["fName"];
            string lName = form["lName"];
            string Email = form["Email"];
            string Phone = form["Phone"];
            string Gender = form["Gender"];


            TempData["name"] = $"{fName} {lName}";
            TempData["email"] = Email;
            TempData["Phone"] = Phone;
            TempData["gender"] = Gender;


            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];

            //Session["IsLoggedIn"] = "false";

            if (email == "alice@gmail.com" && password == "123")
            {
                Session["IsLoggedIn"] = "true";
            }
            else
            {
                Session["IsLoggedIn"] = "false";
            }
            return View("Index");
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}