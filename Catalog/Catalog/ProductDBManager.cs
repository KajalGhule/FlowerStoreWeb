using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public static class ProductDBManager
    {
        public static string conString = @"server=localhost;user=root;database=flowerstore;password=manager";

        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            IDbConnection con = new MySqlConnection(conString);
            string query = "SELECT * FROM flowers";
            IDbCommand cmd = new MySqlCommand(query, con as MySqlConnection);
            try
            {
                con.Open(); // establishing connection

                IDataReader reader = cmd.ExecuteReader();
                //Online data using streaming mechanism
                while (reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string title = reader["Title"].ToString();
                    string description = reader["Description"].ToString();
                    float unitPrice = float.Parse(reader["UnitPrice"].ToString());
                    int quantity = int.Parse(reader["Quantity"].ToString());
                    string image = reader["ImageUrl"].ToString();
                    string category = reader["Category"].ToString();

                    products.Add(new Product()
                    {
                        Id = id,
                        Title = title,
                        Description = description,
                        UnitPrice = unitPrice,
                        Quantity = quantity,
                        ImageUrl = image,
                        Category = category
                    });
                }
                reader.Close();
            }

            catch (MySqlException exp)
            {
                string message = exp.Message;
                //report to developer 
                //log exception message log file
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return products;
        }
    }
}
