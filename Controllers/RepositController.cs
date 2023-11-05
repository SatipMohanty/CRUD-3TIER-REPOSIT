using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3TIER.Models.TIER.entity_class;
using MVC3TIER.Models.TIER.Reposit;

namespace MVC3TIER.Controllers
{
    public class RepositController : Controller
    {
        ireposit_write write=null; 
        ireposit_read read=null;
        reposit_master tran=null;
        public ActionResult Index()
        {
            read=new reposit_master();
            return View(read.dispall("pdept").ToList<dept_cls>());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(dept_cls dept)
        {
            if (ModelState.IsValid)
            {
                write = new reposit_master();
                string result = write.newdept("pdept", dept);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            read= new reposit_master();
            return View(read.search("pdept", id));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            read = new reposit_master();
            return View(read.search("pdept", id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(dept_cls dept)
        {
            if (ModelState.IsValid)
            {
                write= new reposit_master();
                string result = write.editdept("pdept", dept);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            read = new reposit_master();
            return View(read.search("pdept", id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletec(int id)
        {
            if (ModelState.IsValid)
            {
                write= new reposit_master();    
                string result = write.deletedept("pdept", id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}