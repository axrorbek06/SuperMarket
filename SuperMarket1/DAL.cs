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
    internal class DAL
    {
        public void Create(string Name, decimal Price , int CategoryId)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();
                
                string Query = $"INSERT INTO Product (Name, Price , CategoryID ) VALUES ( '{Name}' , {Price} , {CategoryId} )";
                
                SqlCommand cmd = new SqlCommand(Query,connection);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Product created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create the product.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ReadAll()
        { 
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string Query = "select * from product";

                SqlCommand cmd = new SqlCommand(Query,connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("all products are reading ! ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{reader.GetName(0)} \t " +
                        $"{reader.GetName(1)} \t {reader.GetName(2)} \t {reader.GetName(3)} \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (reader.Read()) 
                    {
                        object Id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Price = reader.GetValue(2);
                        object Category = reader.GetValue(3);

                        Console.WriteLine($"{Id} \t {Name} {Price} \t {Category} ");
                    }
                    Console.WriteLine(" \n all products reading finished ! \n");
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" sql error {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("error " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void ReadById(int id )
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string Query = $"select * from product " +
                    $"where id = {id} ";

                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("product is reading by id \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{reader.GetName(0)} \t " +
                        $"{reader.GetName(1)} \t {reader.GetName(2)} ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (reader.Read())
                    {
                        object Id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Price = reader.GetValue(2);

                        Console.WriteLine($"{Id} \t {Name} \t {Price}");
                    }
                    Console.WriteLine(" \n Reading finished ! \n");
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" sql error {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("error " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void Update(int id , string newName , decimal newPrice) 
        { 
          SqlConnection connection = new SqlConnection(
              "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
            try
            {
                connection.Open();

                string Update = $"Update product set Name = '{newName}' , price = {newPrice} " +
                    $"where id = {id}";

                SqlCommand cmd = new SqlCommand(Update , connection);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Updated succesfuly ! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(" sql error : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("error : " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void Delete (int id) 
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
            try
            {
                connection.Open();
                connection.ToString();

                string Delete = $"Delete product where id = {id} ";

                SqlCommand cmd = new SqlCommand (Delete , connection);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" product deleted succesfuly ! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(" sql error : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(" error : " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void ReadPriceBYNum(decimal price)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
            try
            {
                connection.Open();

                string read = $"select * from product " +
                    $"where price > {price} ";

                SqlCommand cmd = new SqlCommand(read, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"products , price > {price} , are reading ! \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{reader.GetName(0)} \t " +
                        $"{reader.GetName(1)} \t {reader.GetName(2)} \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (reader.Read())
                    {
                        object Id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Price = reader.GetValue(2);

                        Console.WriteLine($"{Id} \t {Name} \t {Price}");
                    }
                    Console.WriteLine(" \n products reading finished ! \n");
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(" sql error : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(" error : " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void ReadByName(string Name1)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string Query = $"select * from product " +
                    $"where Name = '{Name1}' ";

                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("product is reading by Name \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{reader.GetName(0)} \t " +
                        $"{reader.GetName(1)} \t {reader.GetName(2)} ");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (reader.Read())
                    {
                        object Id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Price = reader.GetValue(2);

                        Console.WriteLine($"{Id} \t {Name} \t {Price}");
                    }
                    Console.WriteLine(" \n Reading finished ! \n");
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" sql error {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("error " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void CreateCategory(string Name)
        {
            SqlConnection connection = new SqlConnection("Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();
                string create = $"insert into category (Name) values ('{Name}')";
                SqlCommand cmd = new SqlCommand(create , connection);

                int affectedrow = cmd.ExecuteNonQuery();
                if (affectedrow > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("category created succesfuly ! ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("sql error : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("error : "+ex.Message);
            }
            finally { connection.Close(); }
        
        }

        public void UpdateCategory(int id, int CategoryID)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");
            try
            {
                connection.Open();

                string Update = $"Update product set CategoryId = '{CategoryID}' " +
                    $"where id = {id}";

                SqlCommand cmd = new SqlCommand(Update, connection);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" Updated succesfuly ! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(" sql error : " + ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine("error : " + ex.Message);
            }
            finally { connection.Close(); }
        }

        public void ReadByCategory(int CategoryId)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AXRORBEK\\SQLEXPRESS;Initial Catalog=supermarket;Integrated Security=True");

            try
            {
                connection.Open();

                string Query = $"select * from product " +
                    $"where categoryId = {CategoryId}";

                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("products are reading by Category! ");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{reader.GetName(0)} \t " +
                        $"{reader.GetName(1)} \t {reader.GetName(2)} \t {reader.GetName(3)} \n ");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (reader.Read())
                    {
                        object Id = reader.GetValue(0);
                        object Name = reader.GetValue(1);
                        object Price = reader.GetValue(2);
                        object Category = reader.GetValue(3);

                        Console.WriteLine($"{Id} \t {Name}  {Price} \t {Category} ");
                    }
                    Console.WriteLine(" \n products reading by Category finished ! \n");
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" sql error {ex.Message}");
            }
            catch (Exception ex)
            {

                Console.WriteLine("error " + ex.Message);
            }
            finally { connection.Close(); }
        }







    }
}
