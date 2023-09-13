using SuperMarket1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SuperMarket1
{
    internal class ProductDBServis
    {

        public void Create(string Name, decimal Price , int CategoryId)
        {
            string Query = $"INSERT INTO Product (Name, Price , CategoryID )" +
                $" VALUES ( '{Name}' , {Price} , {CategoryId} )";

            Dal.ExecuteNonQuery(Query);
        }

        public void ReadAll()
        {
                string Query = "select * from product";

                ExecuteQuery(Query);
        }

        public void ReadById(int id )
        {
                string Query = $"select * from product " +
                    $"where id = {id} ";
                ExecuteQuery(Query);
        }

        public void Update(int id , string newName , decimal newPrice , int CategoryId) 
        {
            string Update = $"Update product set Name = '{newName}', price = {newPrice}, categoryId = {CategoryId}" +
                      $"where id = {id}";
            Dal.ExecuteNonQuery(Update);
        }

        public void Delete (int id) 
        {
             string Delete = $"Delete product where id = {id} ";
             Dal.ExecuteNonQuery(Delete);

        }

        public void ReadPriceBYNum(decimal price)
        {
                string read = $"select * from product " +
                    $"where price > {price} ";
                ExecuteQuery(read);
        }

        public void ReadByName(string Name1)
        {
                string Query = $"select * from product " +
                    $"where Name = '{Name1}' ";
            ExecuteQuery(Query);
        }
        
        public void ReadByCategory(int CategoryId)
        {
                string Query = $"select * from product " +
                    $"where categoryId = {CategoryId}";
            ExecuteQuery(Query);
        }

        private static List<Product> ExecuteQuery(string query)
        {
            List<Product> Products = new List<Product>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Dal.Connection_String))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    Products = ReadCategoryFromDataReader(command.ExecuteReader());
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

            return Products;
        }

        private static List<Product> ReadCategoryFromDataReader(SqlDataReader reader)
        {
            List<Product> Products = new List<Product>();
            if (reader == null)
            {
                return Products;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return Products;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3));
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                decimal price = reader.GetDecimal(2);
                int category_id = reader.GetInt32(3);

                Products.Add(new Product(id, name,price,category_id));

                Console.WriteLine("{0} \t{1} {2} \t {3} ", id, name , price , category_id);
            }
            Console.WriteLine();
            reader.Close();

            return Products;
        }

    }
}
