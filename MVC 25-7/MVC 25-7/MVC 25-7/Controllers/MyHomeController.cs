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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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


        [HttpGet]
        public ActionResult Details(int id)
        {
            Product NUDetails = db.Products.Find(id);


            if (NUDetails == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }

            return View(NUDetails);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product NUEditGet = db.Products.Find(id);


            if (NUEditGet == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }


            return View(NUEditGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product u)
        {
            if (ModelState.IsValid)
            {
                Product NUEditPost = db.Products.Find(u.id);

                if (NUEditPost == null)
                {
                    Response.Write("<script>alert('id not found in database')");
                    return HttpNotFound();
                }

                NUEditPost.name = u.name;
                NUEditPost.price = u.price;
                NUEditPost.type = u.type;
                NUEditPost.color = u.color;
                NUEditPost.image = u.image;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }





        [HttpGet]
        public ActionResult Delete(Product u)
        {
            Product NUDelete = db.Products.Find(u.id);
            if (NUDelete == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }

            return View(NUDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Product NUDeleteConfirm = db.Products.Find(id);
            if (NUDeleteConfirm == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }

            db.Products.Remove(NUDeleteConfirm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}