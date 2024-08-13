using mvc_5_review_13_8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_5_review_13_8.Controllers
{
    public class HomeController : Controller
    {

        private mvc_review_taskEntities db = new mvc_review_taskEntities();



        public ActionResult Index()
        {
            return View();
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

        //////////////////////////////
        //////////////////////////////
        //////////////////////////////

        public ActionResult products()
        {
            List<string> viewProducts = (List<string>)Session["pruductsList"];

            return View(viewProducts);
        }


        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add(string name, double price, string image) 
        {

            List<string> itemsList;

            if (Session["pruductsList"] != null)
            {
                itemsList = (List<string>)Session["pruductsList"];
            }
            else
            {
                itemsList = new List<string>();
            }

            string newItem = $"{image}, {name}, {price}";
            itemsList.Add(newItem);
            Session["pruductsList"] = itemsList;


            return View();
        }


        ////////////////////////////////
        ////////////////////////////////
        ////////////////////////////////


        public ActionResult productsDB()
        {
            return View(db.minimerces.ToList());
        }


        public ActionResult addDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addDB(minimerce m)
        {

            if (ModelState.IsValid)
            {
                db.minimerces.Add(m);
                db.SaveChanges();
            }
            
            return View();
        }


        /////////////////////////////
        /////////////////////////////
        /////////////////////////////

        public ActionResult productsVM()
        {
            List<viewmodelTest> productsVM = Session["vmProducts"] as List<viewmodelTest>;

            return View(productsVM);
        }


        public ActionResult addVM()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addVM(string image, string name, double? price)
        {

            List<viewmodelTest> VMPRODUCTS;

            if (Session["vmProducts"] != null)
            {
                VMPRODUCTS = Session["vmProducts"] as List<viewmodelTest>;
            }
            else
            {
                VMPRODUCTS= new List<viewmodelTest>();
            }

            viewmodelTest newItemVM = new viewmodelTest()
            {
                image = image,
                name = name,
                price = price,
            };

            VMPRODUCTS.Add(newItemVM);
            Session["vmProducts"] = VMPRODUCTS;
            return View();

        }




    }
}