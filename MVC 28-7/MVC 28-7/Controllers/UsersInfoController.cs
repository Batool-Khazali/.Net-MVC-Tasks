using MVC_28_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_28_7.Controllers
{
    public class UsersInfoController : Controller
    {

        UsersEntities db = new UsersEntities();

        // GET: UsersInfo
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(user u)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(u);
                db.SaveChanges();
            }
            return View("Index");
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {
            user NUEditGet = db.users.Find(id);


            if (NUEditGet == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }


            return View(NUEditGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(user u)
        {
            if (ModelState.IsValid)
            {
                user NUEditPost = db.users.Find(u.id);

                if (NUEditPost == null)
                {
                    Response.Write("<script>alert('id not found in database')");
                    return HttpNotFound();
                }

                NUEditPost.name = u.name;
                NUEditPost.email = u.email;
                NUEditPost.password = u.password;
                NUEditPost.image = u.image;

                //db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }





        [HttpGet]
        public ActionResult Details(int id)
        {
            user NUDetails = db.users.Find(id);


            if (NUDetails == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }

            return View(NUDetails);
        }



        [HttpGet]
        public ActionResult Delete(user u)
        {
            user NUDelete = db.users.Find(u.id);
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
            user NUDeleteConfirm = db.users.Find(id);
            if (NUDeleteConfirm == null)
            {
                Response.Write("<script>alert('id not found in database')");
                return HttpNotFound();
            }

            db.users.Remove(NUDeleteConfirm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}