using MVC_25_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            //Session["IsLoggedIn"] = "false";

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
            var query = db.NewUsers.SingleOrDefault(m => m.email == u.email && m.password == u.password);

            if (query != null)
            {
                //Session["IsLoggedIn"] = "true";

                HttpCookie authCookie = new HttpCookie("AuthCookie", u.email);
                authCookie.Expires = DateTime.Now.AddHours(1); // Set cookie expiration time
                Response.Cookies.Add(authCookie);

                Response.Write("<script>alert('Login successful')</script>");

                return RedirectToAction("Index");
            }
            else
            {
                //Session["IsLoggedIn"] = "false";

                Response.Write("<script>alert('invalid login')</script>");

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
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult signup(NewUser u, string confirmPwd)
        {
            if (ModelState.IsValid)
            {

                if (db.NewUsers.Any(x => x.email == u.email))
                {
                    ViewBag.Message = "email already used";
                }
                else if (u.password != confirmPwd)
                {
                    ViewBag.Message2 = "password do not match";
                }
                else if (db.NewUsers.Any(x => x.email != u.email) && u.password == confirmPwd)
                {
                    db.NewUsers.Add(u);
                    db.SaveChanges();
                    Response.Write("<script>alert('regestration successful')</script>");
                };
            }
            return View();
        }

        public ActionResult Profile(NewUser u)
        {

            HttpCookie authCookie = Request.Cookies["AuthCookie"];

            if (authCookie != null)
            {
                string userEmail = authCookie.Value;

                //if (userEmail != null && userEmail == u.email)
                //{
                //    NewUser getProfile = db.NewUsers.Find(u.email);

                //    return View(getProfile);
                //}


                // Retrieve the user from the database
                var user = db.NewUsers.FirstOrDefault(x => x.email == userEmail);

                if (user != null)
                {
                    return View(user); // Pass the user object to the view
                }

            }
            return View();
        }



        [HttpGet]
        public ActionResult ProfileEdit(NewUser u)
        {
            NewUser NUEditGet = db.NewUsers.Find(u.id);



            if (NUEditGet == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }


            return View(NUEditGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileEdit(NewUser nu, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                NewUser profileEditPost = db.NewUsers.Find(nu.id);
                if (profileEditPost == null)
                {
                    return HttpNotFound("User not found");
                }

                if (upload != null && upload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(upload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);

                    // Create directory if it doesn't exist
                    if (!Directory.Exists(Server.MapPath("~/Content/Images/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/Images/"));
                    }

                    // Save the uploaded file
                    upload.SaveAs(path);
                    profileEditPost.image = fileName; // Update the image property
                }

                // Update other properties
                profileEditPost.fName = nu.fName;
                profileEditPost.lName = nu.lName;
                profileEditPost.userName = nu.userName;
                profileEditPost.Age = nu.Age;
                profileEditPost.email = nu.email;

                db.SaveChanges(); // Save the changes to the database
                return RedirectToAction("Profile"); // Redirect to the Profile view
            }

            return View(nu); // Return the view with the current model if validation fails
        }





        [HttpGet]
        public ActionResult PasswordEdit(int id)
        {
            NewUser NUEditGet = db.NewUsers.Find(id);


            if (NUEditGet == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }


            return View(NUEditGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordEdit(NewUser u, string oldPwd, string newPwd, string confirmPwd)
        {
            if (ModelState.IsValid)
            {
                NewUser pwdEdit = db.NewUsers.Find(u.id);

                if (pwdEdit.password != oldPwd)
                {
                    ViewBag.old = "wrong password";
                }
                else if (newPwd != confirmPwd)
                {
                    ViewBag.con = "password do not match";
                }
                else
                {
                    if (pwdEdit == null)
                    {
                        Response.Write("<script>alert('id not found in database')");
                        return HttpNotFound();
                    }

                    pwdEdit.password = newPwd;


                    db.SaveChanges();
                    return RedirectToAction("Profile");

                }


            }

            return View(u);
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
        public ActionResult Edit([Bind(Include = "id,name,price,type,color,image")] Product u)
        {
            if (ModelState.IsValid)
            {
                Product NUEditPost = db.Products.Find(u.id);

                if (NUEditPost == null)
                {
                    Response.Write("<script>alert('id not found in database')");
                    return HttpNotFound();
                }

                //NUEditPost.name = u.name;
                //NUEditPost.price = u.price;
                //NUEditPost.type = u.type;
                //NUEditPost.color = u.color;
                //NUEditPost.image = u.image;

                db.Entry(u).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(u);
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