using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AegisWcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InstertUserDetails(UserDetails userInfo);        

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "AegisWcfServices.ContractType".
    [DataContract]
    public class UserDetails
    {
        public string firstName = string.Empty;
        public string lastName = string.Empty;
        public string address = string.Empty;
        public string city = string.Empty;
        public int zipCode = -1;
        
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
    }
}
