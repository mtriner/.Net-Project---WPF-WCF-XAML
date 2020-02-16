using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FinalAegisWCFServiceApp
{
    [DataContract]
    public class Customer
    {
        Guid ID = new Guid();
        string firstname = string.Empty;
        string lastname = string.Empty;
        string address = string.Empty;
        string city = string.Empty;
        string state = string.Empty;
        string zipcode = string.Empty;

        [DataMember]
        public Guid CustomerID
        {
            get { return ID; }
            set { ID = value; }
        }
        [DataMember]
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [DataMember]
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        [DataMember]
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        [DataMember]
        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
    }
}