using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3TIER.Models.TIER.entity_class;
using MVC3TIER.Models.TIER.DAL;
using MVC3TIER.Models.TIER.BAL;

namespace MVC3TIER.Controllers
{
    public class threetierController : Controller
    {
        bal ob=new bal();
        public ActionResult Index()
        {
            return View(ob.dispall("pdept").ToList<dept_cls>());
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
            if(ModelState.IsValid)
            {
                string result = ob.newdept("pdept", dept);
                return RedirectToAction("Index");
            }
            return View();  
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(ob.search("pdept",id));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(ob.search("pdept", id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(dept_cls dept)
        {
            if (ModelState.IsValid)
            {
                string result = ob.editdept("pdept", dept);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(ob.search("pdept", id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Deletec(int id)
        {
            if (ModelState.IsValid)
            {
                string result = ob.deletedept("pdept",id );
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}