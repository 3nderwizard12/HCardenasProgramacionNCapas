using DL_EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int query = cnn.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, DateTime.Parse(usuario.FechaNacimiento) , usuario.CURP, usuario.Image , usuario.Role.IdRole, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int query = cnn.UsuarioDelete(usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int queryEF = cnn.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, DateTime.Parse(usuario.FechaNacimiento), usuario.CURP, usuario.Image, usuario.Role.IdRole, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;
            }

            return result;
        }

        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null) 
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;
                            usuario.UserName = row.UserName;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.Email = row.Email;
                            usuario.Password = row.Password;
                            usuario.Sexo = row.Sexo;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd/MMM/yyyy");
                            usuario.CURP = row.CURP;
                            usuario.Image = row.Image;

                            usuario.Role = new ML.Role();
                            usuario.Role.IdRole = row.IdRole;
                            usuario.Role.Name = row.NombreRole;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Calle = row.Calle;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Nombre = row.NombreColonia;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Nombre = row.NombreMunicipio;

                            result.Objects.Add(usuario);

                            //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }   
            return result;
        }

        public static ML.Result GetById(int idUsuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.UsuarioById(idUsuario).FirstOrDefault();


                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.CURP = query.CURP;
                        usuario.Image = query.Image;

                        usuario.Role = new ML.Role();
                        usuario.Role.IdRole = query.IdRole;
                        usuario.Role.Name = query.NombreRole;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInterior = query.NumeroInterios;
                        usuario.Direccion.NumeroExterior = query.Numeroexterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;

                        result.Object = usuario;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the table" + result.Ex;
                //throw;
            }
            return result;
        }
    }
}
