using System.Data;
using System.Data.SqlTypes;
using ShoppingCart;
using Catelog;
using MySql.Data.MySqlClient;

namespace DAL {
    public class CartDALManager
    { 
        public static IDbConnection dbConnection()
        {
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = @"server=localhost;user=root;database=flowerstore;password=manager";
            return conn;
        }
    
        
    }
}