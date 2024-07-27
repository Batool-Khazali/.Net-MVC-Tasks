using MVC_25_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_25_7.Content
{
    public class MyHomeController : Controller
    {
        private Entities db = new Entities();

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

        [HttpGet]
        public ActionResult Products()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult ProductsTable()
        {
            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(NewUser u)
        {
            var query = db.NewUsers.SingleOrDefault(m => m.userName == u.userName && m.password == u.password);

            if (query != null)
            {
                Session["IsLoggedIn"] = "true";

                Response.Write("<script>alert('Login successful')</script>");

                return View("Index");
            }
            else
            {
                Session["IsLoggedIn"] = "false";

                Response.Write("<script>alert('invalid login')</script>");

                return View();
            }

        }


        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(NewUser u)
        {
            if (ModelState.IsValid)
            {
                if (db.NewUsers.Any(x => x.userName == u.userName || x.email == u.email))
                {
                    ViewBag.Message = "name or email already used";
                }
                else
                {
                    db.NewUsers.Add(u);
                    db.SaveChanges();
                    Response.Write("<script>alert('regestration successful')</script>");
                };
            }
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}