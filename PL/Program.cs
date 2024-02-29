using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();
            AseguradoraReference.AseguradoraClient aseguradoraClient = new AseguradoraReference.AseguradoraClient();
            string anwer = "no";
            do
            {
                Console.WriteLine("Selecciona una opcion");
                Console.WriteLine("1 : Add");
                Console.WriteLine("2 : Delete");
                Console.WriteLine("3 : Update");
                Console.WriteLine("4 : GetAll");
                Console.WriteLine("5 : GetById");

                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre de la Aseguradora");
                        aseguradora.Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de Usario");
                        aseguradora.Usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

                        ML.Result resultAdd = aseguradoraClient.Add(aseguradora);

                        Console.WriteLine(resultAdd.Correct);
                        //PL.Users.Add();
                        break;
                    case 2:
                        Console.WriteLine("Ingresa el numero de la Aseguradora");
                        aseguradora.IdAseguradora = Convert.ToInt32(Console.ReadLine());

                        ML.Result resultDelete = aseguradoraClient.Delete(aseguradora);

                        Console.WriteLine(resultDelete.Correct);
                        //PL.Users.Delete();
                        break;
                    case 3:
                        Console.WriteLine("Ingresa el numero de la Aseguradora");
                        aseguradora.IdAseguradora = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nombre de la Aseguradora");
                        aseguradora.Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el numero de Usario");
                        aseguradora.Usuario.IdUsuario = Convert.ToInt32(Console.ReadLine());

                        ML.Result resultUpdate = aseguradoraClient.Update(aseguradora);

                        Console.WriteLine(resultUpdate.Correct);
                        //PL.Users.Update();
                        break;
                    case 4:
                        //PL.Users.GetAll();
                        break;
                    case 5:
                        //PL.Users.GetById();
                        break;
                    default:
                        Console.WriteLine("Select a correct option");
                        break;
                }
                Console.WriteLine("Quiere realizar una nueva");
                anwer = Console.ReadLine();

            } while (anwer == "si" || anwer == "s");
        }
    }
}