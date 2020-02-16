using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace FinalAegisWCFServiceApp 
{    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string InsertCustomer(Customer customer);

        [OperationContract]
        List<Customer> ExistingCustomers();

        [OperationContract]
        string UpdateCustomer(Customer customer);

        [OperationContract]
        string DeleteCustomer(Customer customer);
    }    
}
