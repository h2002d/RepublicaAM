using Hirent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Hirent.DAO
{
    public class CategoryDAO : DAO
    {
        internal void saveCategory(Category category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (category.Id == null)
                        {
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Id", category.Id);
                        }

                        command.Parameters.AddWithValue("@Name", category.Name);
                        command.Parameters.AddWithValue("@ImageSource", category.ImageSource);
                        command.Parameters.AddWithValue("@ParentCategoryId", category.ParentCategoryId);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteCategory(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Category> GetCategories(int? id, bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                        {
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Id", id);
                        }
                        var rdr = command.ExecuteReader();
                        var categoryList = new List<Category>();
                        while (rdr.Read())
                        {
                            var category = new Category();
                            category.Id = Convert.ToInt32(rdr["Id"]);
                            category.ParentCategoryId = Convert.ToInt32(rdr["ParentCategoryId"]);
                            if (!forAdmin)
                            {
                                string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                                try
                                {
                                    category.Name = rdr["Name"].ToString().Split(',')[culture.Equals("AM") ? 0 : culture.Equals("RU") ? 1 : culture.Equals("EN") ? 2 : 0];
                                }
                                catch
                                {
                                    category.Name = rdr["Name"].ToString().Split(',')[0];
                                }
                            }
                            else
                            {
                                category.Name = rdr["Name"].ToString();
                            }
                            category.ImageSource = rdr["ImageSource"].ToString();
                            categoryList.Add(category);
                        }
                        return categoryList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Category> GetCategoriesByParentId(int id,bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategoryByParentId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        var rdr = command.ExecuteReader();
                        var categoryList = new List<Category>();
                        while (rdr.Read())
                        {
                            var category = new Category();
                            category.Id = Convert.ToInt32(rdr["Id"]);
                            category.ParentCategoryId = Convert.ToInt32(rdr["ParentCategoryId"]);
                            if (!forAdmin)
                            {
                                string culture = Thread.CurrentThread.CurrentCulture.Parent.Name.ToUpper();
                                try
                                {
                                    category.Name = rdr["Name"].ToString().Split(',')[culture.Equals("AM") ? 0 : culture.Equals("RU") ? 1 : culture.Equals("EN") ? 2 : 0];
                                }
                                catch
                                {
                                    category.Name = rdr["Name"].ToString().Split(',')[0];
                                }
                            }
                            else
                            {
                                category.Name = rdr["Name"].ToString();
                            }
                            category.ImageSource = rdr["ImageSource"].ToString();
                            categoryList.Add(category);
                        }
                        return categoryList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}