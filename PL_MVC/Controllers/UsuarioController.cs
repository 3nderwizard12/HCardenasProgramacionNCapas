using ML;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta Users";
            }

            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Result resultRole = BL.Role.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            ML.Usuario usuario = new ML.Usuario();
            usuario.Role = new ML.Role();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (resultRole.Correct)
            {
                usuario.Role.Roles = resultRole.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }
            if (idUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(idUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    ML.Result resultDireccion = BL.Direccion.GetById(usuario.Direccion.IdDireccion);
                    ML.Result resultColonia = BL.Colonia.GetById(usuario.Direccion.Colonia.IdColonia);
                    ML.Result resultMunicipio = BL.Municipio.GetById(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    ML.Result resultEstado = BL.Estado.GetById(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Result resultPaisID = BL.Pais.GetById(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);

                    usuario.Role.Roles = resultRole.Objects;

                    usuario.Direccion.Direcciones = resultDireccion.Objects;
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaisID.Objects;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta  " + result.ErrorMessage;
                    return View("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            HttpPostedFileBase file = Request.Files["inpImagen"];

            if (file.ContentLength > 0)
            {
                usuario.Image = Convert.ToBase64String(ConvertToBytes(file));

            }

            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                //add
                result = BL.Usuario.Add(usuario);

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
                result = BL.Usuario.Update(usuario);
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
        public ActionResult Delete(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = idUsuario;

            ML.Result result = BL.Usuario.Delete(usuario);
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

        public JsonResult GetEstado (int idPais)
        {
            var result = BL.Estado.GetById(idPais);

            return Json(result.Objects);
        }

        public JsonResult GetMunicipio(int idEstado)
        {
            var result = BL.Municipio.GetById(idEstado);

            return Json(result.Objects);
        }

        public JsonResult GetColonia(int idMunicipio)
        {
            var result = BL.Colonia.GetById(idMunicipio);

            return Json(result.Objects);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Foto)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            data = reader.ReadBytes((int)Foto.ContentLength);

            return data;
        }
    }
}