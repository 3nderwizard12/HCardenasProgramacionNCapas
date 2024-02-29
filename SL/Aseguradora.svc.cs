using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Aseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Aseguradora.svc or Aseguradora.svc.cs at the Solution Explorer and start debugging.
    public class Aseguradora : IAseguradora
    {
        public SL.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            result = BL.Aseguradora.Add(aseguradora);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            result = BL.Aseguradora.Update(aseguradora);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL.Result Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            result = BL.Aseguradora.Delete(aseguradora);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();

            result = BL.Aseguradora.GetById(IdAseguradora);

            return new SL.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
