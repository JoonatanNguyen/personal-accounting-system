using Personal_Accounting_System_WPFApp.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Accounting_System_WPFApp.Repositories
{
    class CategoryRepository
    {
        public void AddCategory(CategoryDto category)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = "";
                conn.Open();
                query = $"INSERT INTO Categories (CategoryName, FinancialTypeId) VALUES ('{category.CategoryName}', {category.FinancialTypeId})";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<CategoryDto> GetAllCategories()
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };
            List<CategoryDto> categoryList = new List<CategoryDto>();

            try
            {
                string query = "SELECT Id, CategoryName FROM Categories WHERE DisableTime IS NULL";
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoryList.Add(new CategoryDto
                        {
                            CategoryId = int.Parse(reader["Id"]?.ToString() ?? "0"),
                            CategoryName = reader["CategoryName"]?.ToString()
                        });
                    }
                }
                conn.Close();
                return categoryList;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return categoryList;
            }
        }

        public void ModifyCategory(CategoryDto category)
        {
            var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

            try
            {
                string query = "";
                conn.Open();
                query = $"UPDATE Categories SET CategoryName = '{category.CategoryName}', FinancialTypeId = { category.FinancialTypeId } WHERE Id = { category.CategoryId }";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                Console.WriteLine("Data Stored Into Database");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DisableCategory(CategoryDto category)
        {
            {
                var conn = new SqlConnection { ConnectionString = Constants.ConnectionString };

                try
                {
                    conn.Open();
                    Console.WriteLine("Database Connected");

                    SqlCommand command = new SqlCommand("UPDATE Categories SET DisableTime = @date Where Id = @categoryId", conn);
                    command.Parameters.AddWithValue("@date", category.DisableTime);
                    command.Parameters.AddWithValue("@categoryId", category.CategoryId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Data Stored Into Database");
                    conn.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
