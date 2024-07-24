using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace day_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Enter your contact information.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //string name = form["Name"];
            //string country = form["Country"];

            ////TempData["name"] = name;
            ////TempData["country"] = country;
            ////return RedirectToAction("Info");

            //ViewBag.Name = name;
            //ViewBag.Country = country;
            //ViewBag.msg = "Never give up";
            //TempData["msg"] = "Never give up";
            //return View("Info");


            string fName = form["fName"];
            string lName = form["lName"];
            //int Age = Int32.Parse(form["Age"]);
            string Age = form["Age"];
            //int Phone = Int32.Parse(form["Phone"]);
            string Phone = form["Phone"];
            string Gender = form["gender"];
            var Lang = form.GetValues("Lang");
            string City = form["City"];
            var Goals = form.GetValues("Goals");



            TempData["fName"] = fName;
            ViewBag.lName = lName;
            ViewBag.Age = Age;
            ViewBag.Phone = Phone;
            ViewBag.Gender = Gender;
            ViewBag.Lang = Lang;
            ViewBag.City = City;
            ViewBag.Goals = Goals;


            return View("Info");


        }

        //[HttpGet]
        public ActionResult Info() {

            //TempData["msg"] = "Don't give up";
            //ViewBag.Msg = "Keep trying";

            return View();
        }

    }
}