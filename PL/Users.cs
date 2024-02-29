using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Users
    {
        public static void Add()
        {
            ML.User users = new ML.User();

            Console.WriteLine("Escribe tu nombre");
            users.FirstName = Console.ReadLine();
            Console.WriteLine("Escribe tu apellido paterno");
            users.LastName = Console.ReadLine();
            Console.WriteLine("Escribe tu apellido materno");
            users.MotherLastName = Console.ReadLine();
            Console.WriteLine("Escribe tu correo");
            users.Email = Console.ReadLine();
            Console.WriteLine("Escribe tu contraseña");
            users.Password = Console.ReadLine();
            Console.WriteLine("Escribe tu numero de telefono");
            users.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Escribe tu codigo postal");
            users.PotalCode = Console.ReadLine();
            Console.WriteLine("Escribe tu nombre de usuario");
            users.UserName = Console.ReadLine();
            Console.WriteLine("Escribe tu fecha de nacimiento");
            users.Birthday = Console.ReadLine();
            Console.WriteLine("Cual es tu genero");
            users.Gender = Console.ReadLine();
            Console.WriteLine("Escribe tu numero de celular");
            users.MobileNumber = Console.ReadLine();
            Console.WriteLine("Cual es tu CURP");
            users.CURP = Console.ReadLine();
            Console.WriteLine("Imagen");
            users.Image = Console.ReadLine();

            users.Role = new ML.Role();
            Console.WriteLine("Role");
            users.Role.IdRole = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Users.AddLINQ(users);

            if (result.Correct)
            {
                Console.WriteLine("info correctly added");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.User users = new ML.User();

            Console.WriteLine("Selecciona que ID vas a eliminar");
            users.IdUser = Int32.Parse(Console.ReadLine());

            ML.Result result = BL.Users.DeleteEF(users);

            if (result.Correct)
            {
                Console.WriteLine("Id Correctly Deleted");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.User users = new ML.User();

            Console.WriteLine("Que ID va actualizar");
            users.IdUser = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Escribe tu nombre");
            users.FirstName = Console.ReadLine();
            Console.WriteLine("Escribe tu apellido paterno");
            users.LastName = Console.ReadLine();
            Console.WriteLine("Escribe tu apellido materno");
            users.MotherLastName = Console.ReadLine();
            Console.WriteLine("Escribe tu correo");
            users.Email = Console.ReadLine();
            Console.WriteLine("Escribe tu contraseña");
            users.Password = Console.ReadLine();
            Console.WriteLine("Escribe tu numero de telefono");
            users.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Escribe tu codigo postal");
            users.PotalCode = Console.ReadLine();
            Console.WriteLine("Escribe tu nombre de usuario");
            users.UserName = Console.ReadLine();
            Console.WriteLine("Escribe tu fecha de nacimiento");
            users.Birthday = Console.ReadLine();
            Console.WriteLine("Cual es tu genero");
            users.Gender = Console.ReadLine();
            Console.WriteLine("Escribe tu numero de celular");
            users.MobileNumber = Console.ReadLine();
            Console.WriteLine("Cual es tu CURP");
            users.CURP = Console.ReadLine();
            Console.WriteLine("Imagen");
            users.Image = Console.ReadLine();

            users.Role = new ML.Role();
            Console.WriteLine("Role");
            users.Role.IdRole = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Users.UpdateLINQ(users);

            if (result.Correct)
            {
                Console.WriteLine("Id Correctly Updated");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetAll()
        {

            ML.Result result = BL.Users.GetAllLINKQ();

            foreach (ML.User users in result.Objects)
            {
                Console.Write(users.IdUser + " ");
                Console.Write(users.FirstName + " ");
                Console.Write(users.LastName + " ");
                Console.Write(users.MotherLastName + " ");
                Console.Write(users.Email + " ");
                Console.Write(users.Password + " ");
                Console.Write(users.PhoneNumber + " ");
                Console.Write(users.PotalCode + " ");
                Console.Write(users.UserName + " ");
                Console.Write(users.Birthday + " ");
                Console.Write(users.Gender + " ");
                Console.Write(users.MobileNumber + " ");
                Console.Write(users.CURP + " ");
                Console.Write(users.Image + " ");
                Console.Write(users.Role.IdRole + " ");
                Console.Write(users.Role.Name + " ");
                Console.WriteLine();
            }

            if (result.Correct)
            {
                Console.WriteLine("Correct Operation");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetById()
        {

            Console.WriteLine("Selecciona que ID quieres buscar");
            int UsersId = Int32.Parse(Console.ReadLine());

            ML.Result result = BL.Users.GetByIdEF(UsersId);

            ML.User users = (ML.User)result.Object;
            Console.Write(users.IdUser + " ");
            Console.Write(users.FirstName + " ");
            Console.Write(users.LastName + " ");
            Console.Write(users.MotherLastName + " ");
            Console.Write(users.Email + " ");
            Console.Write(users.Password + " ");
            Console.Write(users.PhoneNumber + " ");
            Console.Write(users.PotalCode + " ");
            Console.Write(users.UserName + " ");
            Console.Write(users.Birthday + " ");
            Console.Write(users.Gender + " ");
            Console.Write(users.MobileNumber + " ");
            Console.Write(users.CURP + " ");
            Console.Write(users.Image + " ");
            Console.Write(users.Role.IdRole + " ");
            Console.Write(users.Role.Name);

            if (result.Correct)
            {
                Console.WriteLine("Correct Operation");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
    }
}
