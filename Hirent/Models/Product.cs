using Hirent.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Hirent.Models
{
    public class Product
    {
        static ProductDAO DAO = new ProductDAO();
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public string ImageSource1 { get; set; }
        public string ImageSource2 { get; set; }
        public int View { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }

      

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File1 { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File2 { get; set; }
        public DateTime CreateDate { get; set; }

        internal static int GetProductCountByCategoryId(int id)
        {
            return DAO.GetProductCountByCategoryId(id);
        }

        public void Save()
        {
            DAO.saveProduct(this);
        }

        public static List<Product> GetProduct(int? id, bool forAdmin)
        {
            return DAO.GetProducts(id, forAdmin);
        }

        public static List<Product> GetProductByCategoryId(int id, bool forAdmin,int page)
        {
            return DAO.GetProductsByCategoryId(id, forAdmin,page);
        }

        internal static List<Product> GetProductByPaging(int page)
        {
            return DAO.GetProductsByPage(page);
        }

        internal static List<Product> GetMostViewedItems()
        {
            return DAO.GetMostViewedItems();
        }

        public static void Delete(int id)
        {
            DAO.deleteProduct(id);
        }

        internal static List<Product> GetProductByQuery(string query, bool forAdmin)
        {
            return DAO.GetProductsByQuery(query, forAdmin);
        }
        internal static void  AddView(int productId)
        {
            DAO.AddView(productId);
        }
        public string ContentWithoutHtml()
        {
            return Regex.Replace(Content, "<.*?>", String.Empty);
        }
    }
}