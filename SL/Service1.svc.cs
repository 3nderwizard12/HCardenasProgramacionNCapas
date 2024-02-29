using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Saludo(string nombre)
        {
            return string.Format( "hola {0}", nombre);
        }

        public int Suma(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Resta(int n1, int n2)
        {
            return n1 - n2;
        }

        public int Multiplicasion(int n1, int n2)
        {
            return n1 * n2;
        }

        public int Divicion(int n1, int n2)
        {
            return n1 / n2;
        }
    }
}
