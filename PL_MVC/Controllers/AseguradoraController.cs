using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Aseguradora
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Aseguradora.GetAll();
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            AseguradoraReference.AseguradoraClient aseguradoraClient = new AseguradoraReference.AseguradoraClient();

            var result = aseguradoraClient.GetAll();

            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(aseguradora);
        }

        [HttpGet]
        public ActionResult Form(int? idAseguradora)
        {
            //ML.Result resultUsuario = BL.Usuario.GetAll();

            AseguradoraReference.AseguradoraClient aseguradoraClient = new AseguradoraReference.AseguradoraClient();
            UsuarioReference.UsuarioClient usuarioClient = new UsuarioReference.UsuarioClient();

            var resultUsuario = usuarioClient.GetAll();

            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.Usuario = new ML.Usuario();

            if (resultUsuario.Correct)
            {
                aseguradora.Usuario.Usuarios = resultUsuario.Objects.ToList();
            }
            if (idAseguradora == null)
            {
                return View(aseguradora);
            }
            else
            {
                //ML.Result result = BL.Aseguradora.GetById(idAseguradora.Value);

                var result = aseguradoraClient.GetById(idAseguradora.Value);

                if (result.Correct)
                {
                    aseguradora = (ML.Aseguradora)result.Object;
                    aseguradora.Usuario.Usuarios = resultUsuario.Objects.ToList();
                    return View(aseguradora);
                }
                else 
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            AseguradoraReference.AseguradoraClient aseguradoraClient = new AseguradoraReference.AseguradoraClient();
            //ML.Result result = new ML.Result();
            if (aseguradora.IdAseguradora == 0)
            {
                //Add
                //result = BL.Aseguradora.Add(aseguradora);
                var result = aseguradoraClient.Add(aseguradora);

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
                //Update
                //result = BL.Aseguradora.Update(aseguradora);
                var result = aseguradoraClient.Update(aseguradora);

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
        public ActionResult Delete(int idAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            AseguradoraReference.AseguradoraClient aseguradoraClient = new AseguradoraReference.AseguradoraClient();
            aseguradora.IdAseguradora = idAseguradora;

            //ML.Result result = BL.Aseguradora.Delete(aseguradora);
            var result = aseguradoraClient.Delete(aseguradora);

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