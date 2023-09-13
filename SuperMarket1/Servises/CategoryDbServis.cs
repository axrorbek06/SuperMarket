using SuperMarket1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket1.Servises
{
    internal class CategoryDbServis
    {

        public void CreateCategory(string Name)
        {
                string create = $"insert into category (Name) values ('{Name}')";
            Dal.ExecuteNonQuery(create) ;
        }

        public void UpdateCategory(int id, string Name )
        {
                string Update = $"Update Category set Name = '{Name}' " +
                    $"where id = {id}";
            Dal.ExecuteNonQuery(Update) ;

        }

        public void DeleteCategory(int id) 
        {
            string Delete = $"Delete Category where id = {id} ";
            Dal.ExecuteNonQuery(Delete);
        }

        public void GetAllCategories()
        {
            string query = "SELECT * FROM dbo.Category;";

            ExecuteQuery(query);
        }

        public void GetCategoryById(int id)
        {
            string query = "SELECT * FROM dbo.Category" +
                $" WHERE Id = {id};";

            ExecuteQuery(query);
        }

        public void GetCategoryByName(string categoryName)
        {
            string query = "SELECT * FROM dbo.Category" +
                $" WHERE Category_Name LIKE '%{categoryName}%';";

            ExecuteQuery(query);
        }

        private static List<Category> ExecuteQuery(string query)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Dal.Connection_String))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    categories = ReadCategoryFromDataReader(command.ExecuteReader());
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }

            return categories;
        }

        private static List<Category> ReadCategoryFromDataReader(SqlDataReader reader)
        {
            List<Category> categories = new List<Category>();
            if (reader == null)
            {
                return categories;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return categories;
            }

            Console.WriteLine("{0}\t{1}\t{2}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2));

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);

                categories.Add(new Category(id, name));

                Console.WriteLine("{0} \t{1}", id, name);
            }
            reader.Close();

            return categories;
        }
    }
}
