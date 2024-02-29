using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Saludo(string nombre);

        [OperationContract]
        int Suma(int n1, int n2);

        [OperationContract]
        int Resta(int n1, int n2);

        [OperationContract]
        int Multiplicasion(int n1, int n2);

        [OperationContract]
        int Divicion(int n1, int n2);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
