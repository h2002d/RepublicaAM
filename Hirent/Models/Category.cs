using Hirent.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hirent.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public int ParentCategoryId { get; set; }
        static CategoryDAO DAO = new CategoryDAO();

        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        public void Save()
        {
            DAO.saveCategory(this);
        }
        public static List<Category> GetCategory(int? id, bool forAdmin)
        {
            return DAO.GetCategories(id, forAdmin);
        }

        public static List<Category> GetCategoryByParentId(int id, bool forAdmin)
        {
            return DAO.GetCategoriesByParentId(id, forAdmin);
        }

        public static void Delete(int id)
        {
            DAO.deleteCategory(id);
        }
    }
}