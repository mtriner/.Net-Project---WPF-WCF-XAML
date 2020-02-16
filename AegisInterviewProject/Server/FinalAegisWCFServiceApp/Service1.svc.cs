using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace FinalAegisWCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {      
        public string InsertCustomer(Customer customer)
        {
            string Message = string.Empty;
            SqlConnection con = new SqlConnection();
            con.ConnectionString= "Data Source=DESKTOP-2THLGGJ\\AEGISMSSQLSERVER;" + "Initial Catalog=Aegis;" + "User ID=sa;" + "Password=password1;";
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer(ID, LastName, FirstName, Address, City, State, ZipCode) VALUES (@ID, @LastName, @FirstName, @Address, @City, @State, @ZipCode);", con);
            Guid guid = Guid.NewGuid();            
            customer.CustomerID = guid;
            cmd.Parameters.AddWithValue("@ID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = customer.FirstName + " " + customer.LastName + " was added successully.";
            }
            else
            {
                Message = customer.FirstName + " " + customer.LastName + " failed to be added.";
            }
            con.Close();
            return Message;
        }
        public List<Customer> ExistingCustomers()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2THLGGJ\\AEGISMSSQLSERVER;" + "Initial Catalog=Aegis;" + "User ID=sa;" + "Password=password1;";
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", con);
            List<Customer> ExistingCustomers = new List<Customer>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //add customer w/ these properties
                Customer customer = new Customer();
                customer.CustomerID = (Guid)reader["ID"];
                customer.LastName= (string)reader["LastName"];
                customer.FirstName= (string)reader["FirstName"];
                customer.Address = (string)reader["Address"];
                customer.City = (string)reader["City"];
                customer.State = (string)reader["State"];
                customer.ZipCode = (string)reader["ZipCode"];
                ExistingCustomers.Add(customer);
            }
            con.Close();

            return ExistingCustomers;
        }

        public string UpdateCustomer(Customer customer)
        {
            string Message = string.Empty;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2THLGGJ\\AEGISMSSQLSERVER;" + "Initial Catalog=Aegis;" + "User ID=sa;" + "Password=password1;";
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Customer SET LastName = @LastName, FirstName = @FirstName, Address = @Address, City = @City, State = @State, ZipCode = @ZipCode WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@City", customer.City);
            cmd.Parameters.AddWithValue("@State", customer.State);
            cmd.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = customer.FirstName + " " + customer.LastName + " was modified successully.";
            }
            else
            {
                Message = customer.FirstName + " " + customer.LastName + " failed to be modified.";
            }
            con.Close();

            return Message;
        }

        public string DeleteCustomer(Customer customer)
        {
            string Message = string.Empty;
            var con = SqlConnect();            
            SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", customer.CustomerID);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = customer.FirstName + " " + customer.LastName + " was deleted successully.";
            }
            else
            {
                Message = customer.FirstName + " " + customer.LastName + " failed to be deleted.";
            }
            con.Close();

            return Message;
        }
        public bool CheckExists(Customer customer)
        {
            var con = SqlConnect();
            SqlCommand cmd = new SqlCommand("Select * WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", customer.CustomerID);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                return true;
            }
            else 
            {
                return false; 
            }
        }
        public SqlConnection SqlConnect()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2THLGGJ\\AEGISMSSQLSERVER;" + "Initial Catalog=Aegis;" + "User ID=sa;" + "Password=password1;";
            con.Open();
            return con;
        }
    }
}