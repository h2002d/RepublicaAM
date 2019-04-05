using Hirent.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hirent.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var productList = Product.GetProduct(null, true);
            return View(productList);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = Models.Category.GetCategory(null, false);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = Product.GetProduct(id, true).First();
            ViewBag.Categories = Models.Category.GetCategory(null, false);
            return View("Create", product);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id != null && product.File == null && product.File1 == null && product.File2 == null)
                {
                    product.Save();
                    return RedirectToAction("Index");
                }
                string targetFolder = HttpContext.Server.MapPath("~/img/news/");

                if (product.File != null)
                {
                    string targetPath = Path.Combine(targetFolder, product.File.FileName);
                    product.File.SaveAs(targetPath);
                    product.ImageSource = "/img/news/" + product.File.FileName;
                }
                if (product.File1 != null)
                {
                    string targetPath1 = Path.Combine(targetFolder, product.File1.FileName);
                    product.File1.SaveAs(targetPath1);
                    product.ImageSource1 = "/img/news/" + product.File1.FileName;

                }
                if (product.File2 != null)
                {
                    string targetPath2 = Path.Combine(targetFolder, product.File2.FileName);
                    product.File2.SaveAs(targetPath2);
                    product.ImageSource2 = "/img/news/" + product.File2.FileName;
                }
                product.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Product.Delete(id);
            return RedirectToAction("Index");
        }


    }
}