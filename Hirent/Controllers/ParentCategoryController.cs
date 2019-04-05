using Hirent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hirent.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class ParentCategoryController : Controller
    {
        // GET: ParentCategory
        public ActionResult Index()
        {
            var categoryList = ParentCategory.GetCategory(null,true);
            return View(categoryList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = ParentCategory.GetCategory(id, true).First();
            return View("Create", category);
        }

        [HttpPost]
        public ActionResult Create(ParentCategory category)
        {
            if (ModelState.IsValid)
            {
                category.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            ParentCategory.Delete(id);
            return RedirectToAction("Index");
        }
    }
}