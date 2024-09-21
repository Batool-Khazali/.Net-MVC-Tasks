using MVC_Code_first_19_9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Code_first_19_9.Controllers
{
    public class LoginController : Controller
    {

        private readonly MyDb db = new MyDb();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
            if (ModelState.IsValid)
            {
                var query = db.Users.SingleOrDefault(m => m.Email == u.Email && m.Password == u.Password);

                if (query != null)
                {
                    

                    HttpCookie authCookie = new HttpCookie("AuthCookie", u.Email);
                    authCookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(authCookie);

                    Response.Write("<script>alert('Login successful')</script>");

                    return RedirectToAction("Index" , "Home");


                }
                else
                {

                    ModelState.AddModelError("", "Invalid email or password.");

                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        public ActionResult Logout()
        {
            if (Request.Cookies["AuthCookie"] != null)
            {
                var cookie = new HttpCookie("AuthCookie");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login", "Login");
        }




    }
}