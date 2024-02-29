using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAseguradora" in both code and config file together.
    [ServiceContract]
    public interface IAseguradora
    {
        [OperationContract]
        SL.Result Add(ML.Aseguradora aseguradora);

        [OperationContract]
        SL.Result Update(ML.Aseguradora aseguradora);

        [OperationContract]
        SL.Result Delete(ML.Aseguradora aseguradora);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL.Result GetById(int IdAseguradora);
    }
}
