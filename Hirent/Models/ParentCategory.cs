using Hirent.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hirent.Models
{
    public class ParentCategory
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<Category> ChildCategories()
        {
            return Category.GetCategoryByParentId(Convert.ToInt32(Id),false);
        }

        static ParentCategoryDAO DAO = new ParentCategoryDAO();

        public void Save()
        {
            DAO.saveCategory(this);
        }
        public static List<ParentCategory> GetCategory(int? id, bool forAdmin)
        {
            return DAO.GetCategories(id,forAdmin);
        }

        public static void Delete(int id)
        {
            DAO.deleteCategory(id);
        }
    }
}