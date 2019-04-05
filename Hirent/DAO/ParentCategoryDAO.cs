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
    public class ParentCategoryDAO : DAO
    {
        internal void saveCategory(ParentCategory category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_SaveParentCategory", sqlConnection))
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
                using (SqlCommand command = new SqlCommand("sp_DeleteParentCategory", sqlConnection))
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

        internal List<ParentCategory> GetCategories(int? id,bool forAdmin)
        {
            using (SqlConnection sqlConnection = new SqlConnection(BPM_DB_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("sp_GetParentCategory", sqlConnection))
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
                        var categoryList = new List<ParentCategory>();
                        while (rdr.Read())
                        {
                            var category = new ParentCategory();
                            category.Id = Convert.ToInt32(rdr["Id"]);
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