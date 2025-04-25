using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CRM {
    public static class CustomerDisDBManager { 
        public static string conString = string.Empty;
        static CustomerDisDBManager()
        {
           conString = @"server=localhost;user=root;database=flowerstore;password=manager";
        }  

        public static List<Customer> GetAll() {
            List<Customer> customers = new List<Customer>();
            IDbConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            string query = "SELECT * FROM customers";
           
            MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();            
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                foreach (DataRow datarow in dt.Rows)
                {
                    int id = int.Parse(datarow["Id"].ToString());
                    string name = datarow["Name"].ToString();
                    string location = datarow["Location"].ToString();
                    string email = datarow["Email"].ToString();
                    int age = int.Parse(datarow["Age"].ToString());
                    string contactNo = datarow["ContactNumber"].ToString();
                  
                    Customer cust = new Customer
                    {
                        Id=id,
                        Name = name,
                        Location = location,
                        Email=email,
                        Age=age,
                        ContactNumber=contactNo,
                    };
                    customers.Add(cust);
                }
            }
            catch (MySqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return customers;
        }

        public static Customer GetById(int customerId)
        {
            Customer theCustomer = null;
            IDbConnection con = new MySqlConnection();
            con.ConnectionString = conString;

            string query = "SELECT * FROM customers WHERE Id=@CustomerId";
            MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
            cmd.Parameters.AddWithValue("@CustomerId", customerId); 

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0) 
                {
                    DataColumn[] keyColumns = new DataColumn[1];
                    keyColumns[0] = dt.Columns["Id"];
                    dt.PrimaryKey = keyColumns;

                    DataRow datarow = dt.Rows.Find(customerId); 

                    if (datarow != null) 
                    {
                        int id = int.Parse(datarow["Id"].ToString());
                        string name = datarow["Name"].ToString();
                        string location = datarow["Location"].ToString();
                        string email = datarow["Email"].ToString();
                        int age = int.Parse(datarow["Age"].ToString());
                        string contactNo = datarow["ContactNumber"].ToString();

                        theCustomer = new Customer
                        {
                            Id = id,
                            Name = name,
                            Location = location,
                            Email = email,
                            Age = age,
                            ContactNumber = contactNo,
                        };
                    }
                }
            }
            catch (MySqlException ee)
            {
                Console.WriteLine("MySQL Error: " + ee.Message); 
            }
            return theCustomer;
        }


        public static bool Insert(Customer newCustomer)
        {
            bool status = false;

            IDbConnection con = new MySqlConnection();
            con.ConnectionString = conString;

            string cmdStr = "select * from customers";
            IDbCommand cmd = new MySqlCommand();
            
            cmd.Connection = con as MySqlConnection;
            cmd.CommandText = cmdStr;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();

            try
            {
                MySqlCommandBuilder cmdBldr = new MySqlCommandBuilder(da);
                MySqlCommand deleteCommand = cmdBldr.GetDeleteCommand();
                string strDeleteCommand = deleteCommand.CommandText;

                da.Fill(ds);

                DataRow newRow = ds.Tables[0].NewRow();
                newRow["Id"] = newCustomer.Id;
                newRow["Name"] = newCustomer.Name;
                newRow["Email"] = newCustomer.Email;
                newRow["ContactNumber"] = newCustomer.ContactNumber;
                newRow["Location"] = newCustomer.Location;
                newRow["Age"] = newCustomer.Age;
                ds.Tables[0].Rows.Add(newRow);
                da.Update(ds);
                status = true;
            }
            
            catch (MySqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;
        }

        public static bool Update(Customer theCustomer)
        {
            bool status = false;

            List<Customer> allCustomers = new List<Customer>();
            
            IDbConnection con = new MySqlConnection();
            con.ConnectionString = conString;

            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM customers";
            cmd.Connection = con;
            
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            
            try
            {
                MySqlCommandBuilder cmdbldr = new MySqlCommandBuilder(da);
                da.Fill(ds);

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(theCustomer.Id);
                datarow["Name"] = theCustomer.Name;
                datarow["Email"] = theCustomer.Email;
                datarow["ContactNumber"] = theCustomer.ContactNumber;
                datarow["Location"] = theCustomer.Location;
                datarow["Age"] = theCustomer.Age;

                da.Update(ds);
            }
            catch (MySqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;
        }

        public static bool Delete(int customerId)
        {
            bool status = false;

            IDbConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "SELECT * FROM customers";
            cmd.Connection = con;
            
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();

            try
            {
                MySqlCommandBuilder cmdbldr = new MySqlCommandBuilder(da);
                da.Fill(ds);

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(customerId);
                datarow.Delete();
                da.Update(ds);
                status = true;
            }

            catch (MySqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;
        }
    }
}