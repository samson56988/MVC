using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        CRUDEntities ob = new CRUDEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getdata()
        {
            List<Crud> data = ob.Cruds.ToList<Crud>();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult Postdata(Crud ob_c)
        {
            if(ob_c.id > 0)
            {

                Crud crud = ob.Cruds.Where(model => model.id == ob_c.id).FirstOrDefault<Crud>();
                crud.name = ob_c.name;
                crud.email = ob_c.email;
                crud.address = ob_c.address;
                crud.country = ob_c.country;
                crud.pin = ob_c.pin;
                ob.SaveChanges();
                return Json( new { result = true,message = "Data Updated Successfully"}, JsonRequestBehavior.AllowGet);

            }
            else
            {

                
                
                    Crud obb = new Crud();
                    obb.name = ob_c.name;
                    obb.email = ob_c.email;
                    obb.address = ob_c.address;
                    obb.country = ob_c.country;
                    obb.pin = ob_c.pin;
                    ob.Cruds.Add(ob_c);
                    ob.SaveChanges(); 

                
                return Json(new { result = true, message = "Data Saved Successfully" }, JsonRequestBehavior.AllowGet);

            }


           

        }


        public JsonResult delete(int id)
        {
            Crud d = ob.Cruds.Where(m => m.id == id).FirstOrDefault<Crud>();
            ob.Cruds.Remove(d);
            ob.SaveChanges(); 

            return Json("success", JsonRequestBehavior.AllowGet); 
        }


        public ActionResult GetEdit(int id)
        {

            var de = ob.Cruds.Where(model => model.id == id).FirstOrDefault();


            return Json(de, JsonRequestBehavior.AllowGet);
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