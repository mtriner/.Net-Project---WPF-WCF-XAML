using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AegisWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {        
        public string InsertCustomerDetails(CustomerDetails customerInfo)
        {
            string Message = String.Empty;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-2THLGGJ/AEGISMSSQLSERVER;Initial Catalog=Aegis;User ID=sa;Password=password1");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into Customer Table(ID, LastName, FirstName, Address, City, State, ZipCode)" +
                "VALUES(@ID, @LastName, @FirstName, @Address, @City, @State, @ZipCode", con);
            cmd.Parameters.AddWithValue("@ID", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@LastName", customerInfo.LastName);
            cmd.Parameters.AddWithValue("@FirstName", customerInfo.FirstName);
            cmd.Parameters.AddWithValue("@Address", customerInfo.address);
            cmd.Parameters.AddWithValue("@City", customerInfo.City);
            cmd.Parameters.AddWithValue("@State", customerInfo.State);
            cmd.Parameters.AddWithValue("@ZipCode", customerInfo.ZipCode);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = customerInfo.FirstName + " " + customerInfo.LastName + "details inserted successfully";
            }
            else 
            {
                Message = customerInfo.FirstName + " " + customerInfo.LastName + "details inserted successfully";
            }
            con.Close();
            return Message;
        }
    }
}
