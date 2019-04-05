using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hirent.Models;
namespace Hirent.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.ParentCategories = Models.Category.GetCategory(null, false);
            var items = Models.Product.GetProduct(null, false).Count > 12 ? Models.Product.GetProduct(null, false).Take(12) : Models.Product.GetProduct(null, false);
            ViewBag.RightScrollbarItems = items;
            ViewBag.MostViewed = Models.Product.GetMostViewedItems();
            ViewBag.Recents = items.Take(4);
            return PartialView();
        }

        public ActionResult Category(int id)
        {
            // ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null,false);
            var category = Models.Category.GetCategory(id, false).First();
            ViewBag.PageCount = Models.Product.GetProductCountByCategoryId(id)+1;
            ViewBag.ParentCategories = Models.Category.GetCategory(null, false);
            return PartialView(category);
        }

        public ActionResult CategoryPartial(int categoryId, int page)
        {
            var itemList = Models.Product.GetProductByCategoryId(categoryId, false, page);
            return PartialView(itemList);
        }
        public ActionResult RightScrollbar(int page)
        {
            var itemList = Models.Product.GetProductByPaging(page);
            return PartialView(itemList);
        }
        public ActionResult Search(string query)
        {
            var product = Product.GetProductByQuery(query, false);
            ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null, false);
            ViewBag.CategoryName = string.Format(@"Search results for ""{0}""", query);
            return PartialView("Category", product);
        }
        //public ActionResult About()
        //{
        //    ViewBag.ParentCategories = Models.ParentCategory.GetCategory(null, false);
        //    return PartialView();
        //}

        public ActionResult Contact()
        {
            ViewBag.ParentCategories = Models.Category.GetCategory(null, false);
            return PartialView();
        }

        public ActionResult News(int id)
        {
            var product = Product.GetProduct(id, false).First();
            Product.AddView(id);
            ViewBag.ParentCategories = Models.Category.GetCategory(null, false);
            return PartialView(product);
        }
        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguages().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}