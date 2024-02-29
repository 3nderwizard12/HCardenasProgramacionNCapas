﻿using DL_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.DireccionGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Direccion direccion = new ML.Direccion();

                            direccion.IdDireccion = row.IdDireccion;
                            direccion.Calle = row.Calle;
                            direccion.NumeroInterior = row.NumeroInterios;
                            direccion.NumeroExterior = row.Numeroexterior;

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = row.IdColonia;
                            direccion.Colonia.Nombre = row.NombreColonia;

                            direccion.Usuario = new ML.Usuario();
                            direccion.Usuario.IdUsuario = row.IdUsuario;
                            direccion.Usuario.Nombre = row.NombreUsuario;
                            direccion.Usuario.ApellidoPaterno = row.ApellidoPaterno;
                            direccion.Usuario.ApellidoMaterno = row.ApellidoMaterno;
                            direccion.Usuario.NombreCompleto = row.NombreUsuario + row.ApellidoPaterno + row.ApellidoMaterno;

                            result.Objects.Add(direccion);

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

        public static ML.Result GetById(int idDireccion)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.DireccionGetById(idDireccion).FirstOrDefault();


                    if (query != null)
                    {
                        ML.Direccion direccion = new ML.Direccion();
                        direccion.IdDireccion = query.IdDireccion;
                        direccion.Calle = query.Calle;
                        direccion.NumeroExterior = query.NumeroExterior;
                        direccion.NumeroInterior = query.NumeroInterios;

                        result.Object = direccion;
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
