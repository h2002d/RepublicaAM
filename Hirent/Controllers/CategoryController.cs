using Hirent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hirent.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categoryList = Category.GetCategory(null,true);
            return View(categoryList);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = Models.ParentCategory.GetCategory(null, false);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = Category.GetCategory(id,true).First();
            ViewBag.Categories = Models.ParentCategory.GetCategory(null,false);
            return View("Create", category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id != null && category.File == null)
                {
                    category.Save();
                    return RedirectToAction("Index");
                }
                if (category.File != null)
                {
                    string targetFolder = HttpContext.Server.MapPath("~/images");
                    string targetPath = Path.Combine(targetFolder, category.File.FileName);
                    category.File.SaveAs(targetPath);
                    category.ImageSource = "/images/" + category.File.FileName;
                }
                else
                    category.ImageSource =" ";

                category.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Category.Delete(id);
            return RedirectToAction("Index");
        }
    }
}