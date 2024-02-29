using BL;
using Microsoft.Ajax.Utilities;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult GetAll()
        {
            ML.Result result = BL.Users.GetAllEF();
            ML.User user = new ML.User();

            if (result.Correct)
            {
                user.Users = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(user);
        }
        [HttpGet]
        public ActionResult Form(int? iduser)
        {
            if (iduser == null)
            {
                return View();
            }
            else
            {
                ML.Result result = BL.Users.GetByIdEF(iduser.Value);

                if (result.Correct)
                {
                    ML.User user = (ML.User)result.Object;
                    return View(user);
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.User user)
        {
            ML.Result result = new ML.Result();
            if (user.IdUser == 0)
            {
                //add
                result = BL.Users.AddEF(user);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro correctamente insertado";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el registro";
                }
            }
            else
            {
                //update
                result = BL.Users.UpdateEF(user);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro correctamente actualizado";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro";
                }

            }
            return View("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int iduser)
        {
            ML.User user = new User();
            user.IdUser = iduser;

            ML.Result result = BL.Users.DeleteEF(user);
            if (result.Correct)
            {
                ViewBag.Message = "Registro correctamente Eliminado";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el registro";
            }
            return View("Modal");
        }
    }
}