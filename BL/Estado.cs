﻿using DL_EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.EstadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var row in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = row.IdEstado;
                            estado.Nombre = row.Nombre;

                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = row.IdPais;
                            estado.Pais.Nombre = row.NombrePais;

                            result.Objects.Add(estado);

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

        public static ML.Result GetById(int idPais)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var query = cnn.EstadoGetById(idPais).ToList();

                    result.Objects = new List<object>();

                    foreach (var row in query)
                    {
                        ML.Estado estado = new ML.Estado();

                        estado.IdEstado = row.IdEstado;
                        estado.Nombre = row.Nombre;

                        result.Objects.Add(estado);

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
