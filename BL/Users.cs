using DL;
using DL_EF;
using Microsoft.Win32;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Users
    {
        public static ML.Result Add(ML.User User)
        {

            ML.Result result = new ML.Result();

            try
			{
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UsersAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@Name", SqlDbType.VarChar);
                        collection[0].Value = User.FirstName;

                        collection[0] = new SqlParameter("@Name", SqlDbType.VarChar);
                        collection[0].Value = User.LastName;

                        collection[0] = new SqlParameter("@Name", SqlDbType.VarChar);
                        collection[0].Value = User.MotherLastName;

                        collection[1] = new SqlParameter("@Email", SqlDbType.VarChar);
                        collection[1].Value = User.Email;

                        collection[2] = new SqlParameter("@Password", SqlDbType.VarChar);
                        collection[2].Value = User.Password;

                        collection[3] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
                        collection[3].Value = User.PhoneNumber;

                        collection[4] = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                        collection[4].Value = User.PotalCode;

                        collection[5] = new SqlParameter("@UserName", SqlDbType.VarChar);
                        collection[5].Value = User.UserName;

                        collection[6] = new SqlParameter("@Birthday", SqlDbType.VarChar);
                        collection[6].Value = User.Birthday;

                        collection[7] = new SqlParameter("@Gender", SqlDbType.Char);
                        collection[7].Value = User.Gender;

                        collection[8] = new SqlParameter("@MobileNumber", SqlDbType.VarChar);
                        collection[8].Value = User.MobileNumber;

                        collection[9] = new SqlParameter("@CURP", SqlDbType.VarChar);
                        collection[9].Value = User.CURP;

                        collection[10] = new SqlParameter("@Image", SqlDbType.VarChar);
                        collection[10].Value = User.Image;

                        collection[11] = new SqlParameter("@IdRole", SqlDbType.TinyInt);
                        collection[11].Value = User.Role.IdRole;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result AddQuery(ML.User User)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "INSERT INTO Users(UsersName, UsersEmail, UsersPassword, UsersPhoneNumber, UsersPostalCode, UsersUserName, UsersBirthday, UsersGender, UsersMobileNumber, UsersCURP, UsersImage, RoleId)VALUES(@UsersName, @UsersEmail, @UsersPassword, @UsersPhoneNumber, @UsersPostalCode, @UsersUserName, @UsersBirthday, @UsersGender, @UsersMobileNumber, @UsersCURP, @UsersImage, @RoleId)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[0].Value = User.FirstName;

                        collection[0] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[0].Value = User.LastName;

                        collection[0] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[0].Value = User.MotherLastName;

                        collection[1] = new SqlParameter("@UsersEmail", SqlDbType.VarChar);
                        collection[1].Value = User.Email;

                        collection[2] = new SqlParameter("@UsersPassword", SqlDbType.VarChar);
                        collection[2].Value = User.Password;

                        collection[3] = new SqlParameter("@UsersPhoneNumber", SqlDbType.VarChar);
                        collection[3].Value = User.PhoneNumber;

                        collection[4] = new SqlParameter("@UsersPostalCode", SqlDbType.VarChar);
                        collection[4].Value = User.PotalCode;

                        collection[5] = new SqlParameter("@UsersUserName", SqlDbType.VarChar);
                        collection[5].Value = User.UserName;

                        collection[6] = new SqlParameter("@UsersBirthday", SqlDbType.VarChar);
                        collection[6].Value = User.Birthday;

                        collection[7] = new SqlParameter("@UsersGender", SqlDbType.Char);
                        collection[7].Value = User.Gender;

                        collection[8] = new SqlParameter("@UsersMobileNumber", SqlDbType.VarChar);
                        collection[8].Value = User.MobileNumber;

                        collection[9] = new SqlParameter("@UsersCURP", SqlDbType.VarChar);
                        collection[9].Value = User.CURP;

                        collection[10] = new SqlParameter("@UsersImage", SqlDbType.VarChar);
                        collection[10].Value = User.Image;

                        User.Role = new ML.Role();

                        collection[11] = new SqlParameter("@RoleId", SqlDbType.TinyInt);
                        collection[11].Value = User.Role.IdRole;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result AddEF(ML.User User)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int queryEF = cnn.UserAdd(User.FirstName, User.LastName, User.MotherLastName, User.Email, User.Password, User.PhoneNumber, User.PotalCode, User.UserName, User.Birthday, User.Gender, User.MobileNumber, User.CURP, User.Image, User.Role.IdRole);

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

        public static ML.Result AddLINQ(ML.User User)
        {
            ML.Result result = new Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    DL_EF.User UserLINQ = new DL_EF.User();

                    UserLINQ.FirstName = User.FirstName;
                    UserLINQ.LastName = User.LastName;
                    UserLINQ.MotherLastName = User.MotherLastName;
                    UserLINQ.Email = User.Email;
                    UserLINQ.Password = User.Password;
                    UserLINQ.PhoneNumber = User.PhoneNumber;
                    UserLINQ.PostalCode = User.PotalCode;
                    UserLINQ.UserName = User.UserName;
                    UserLINQ.Birthday = DateTime.Parse(User.Birthday);
                    UserLINQ.Gender = User.Gender;
                    UserLINQ.MobileNumber = User.MobileNumber;
                    UserLINQ.CURP = User.CURP;
                    UserLINQ.Image = User.Image;
                    UserLINQ.IdRole = User.Role.IdRole;

                    cnn.Users.Add(UserLINQ);
                    cnn.SaveChanges();

                    result.Correct = true;
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

        public static ML.Result Delete(ML.User User)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UsersDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        //SqlParameter[] collection = new SqlParameter[1];

                        //collection[0] = new SqlParameter("@UsersId", SqlDbType.Int);
                        //collection[0].Value = Users.UsersId;
                        //cmd.Parameters.AddRange(collection);

                        SqlParameter parameter = new SqlParameter
                        {
                            ParameterName = "@IdUsers", 
                            SqlDbType = SqlDbType.Int, 
                            Value = User.IdUser, 
                            Direction = ParameterDirection.Input 
                        };


                        cmd.Parameters.Add(parameter);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result DeleteEF(ML.User User)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int queryEF = cnn.UserDelete(User.IdUser);

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

        public static ML.Result DeleteLINKQ(ML.User User)
        {
            ML.Result result= new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryLINKQ = (from tblUsers in cnn.Users
                                      where tblUsers.IdUser == User.IdUser
                                      select tblUsers).First();

                    cnn.Users.Remove(queryLINKQ);
                    cnn.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "An error occurred while inserting the record into the Student table" + result.Ex;
                //throw;;
            }

            return result;
        }

        public static ML.Result Update(ML.User User)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UsersUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[15];

                        collection[0] = new SqlParameter("Id@Users", SqlDbType.Int);
                        collection[0].Value = User.IdUser;

                        collection[1] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                        collection[1].Value = User.FirstName;

                        collection[2] = new SqlParameter("@LastName", SqlDbType.VarChar);
                        collection[2].Value = User.LastName;

                        collection[3] = new SqlParameter("@MotherLastName", SqlDbType.VarChar);
                        collection[3].Value = User.MotherLastName;

                        collection[4] = new SqlParameter("@Email", SqlDbType.VarChar);
                        collection[4].Value = User.Email;

                        collection[5] = new SqlParameter("@Password", SqlDbType.VarChar);
                        collection[5].Value = User.Password;

                        collection[6] = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
                        collection[6].Value = User.PhoneNumber;

                        collection[7] = new SqlParameter("@PostalCode", SqlDbType.VarChar);
                        collection[7].Value = User.PotalCode;

                        collection[8] = new SqlParameter("@UserName", SqlDbType.VarChar);
                        collection[8].Value = User.UserName;

                        collection[9] = new SqlParameter("@Birthday", SqlDbType.VarChar);
                        collection[9].Value = User.Birthday;

                        collection[10] = new SqlParameter("@Gender", SqlDbType.VarChar);
                        collection[10].Value = User.Gender;

                        collection[11] = new SqlParameter("@MobileNumber", SqlDbType.VarChar);
                        collection[11].Value = User.MobileNumber;

                        collection[12] = new SqlParameter("@CURP", SqlDbType.VarChar);
                        collection[12].Value = User.CURP;

                        collection[13] = new SqlParameter("@Image", SqlDbType.VarChar);
                        collection[13].Value = User.Image;

                        collection[14] = new SqlParameter("@IdRole", SqlDbType.TinyInt);
                        collection[14].Value = User.Role.IdRole;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result UpdateQuery(ML.User User)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UPDATE Users SET UsersName = @UsersName, UsersEmail = @UsersEmail, UsersPassword = @UsersPassword, UsersPhoneNumber = @UsersPhoneNumber, UsersPostalCode = @UsersPostalCode, UsersUserName = @UsersUserName, UsersBirthday = @UsersBirthday, @UsersGender = @UsersGender, @UsersMobileNumber = @UsersMobileNumber, @UsersCURP = @UsersCURP, @UsersImage = @UsersImage, @RoleId = @RoleId WHERE UsersId = @UsersId";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@UsersId", SqlDbType.Int);
                        collection[0].Value = User.IdUser;

                        collection[1] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[1].Value = User.FirstName;

                        collection[1] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[1].Value = User.LastName;

                        collection[1] = new SqlParameter("@UsersName", SqlDbType.VarChar);
                        collection[1].Value = User.MotherLastName;

                        collection[2] = new SqlParameter("@UsersEmail", SqlDbType.VarChar);
                        collection[2].Value = User.Email;

                        collection[3] = new SqlParameter("@UsersPassword", SqlDbType.VarChar);
                        collection[3].Value = User.Password;

                        collection[4] = new SqlParameter("@UsersPhoneNumber", SqlDbType.VarChar);
                        collection[4].Value = User.PhoneNumber;

                        collection[5] = new SqlParameter("@UsersPostalCode", SqlDbType.VarChar);
                        collection[5].Value = User.PotalCode;

                        collection[6] = new SqlParameter("@UsersUserName", SqlDbType.VarChar);
                        collection[6].Value = User.UserName;

                        collection[7] = new SqlParameter("@UsersBirthday", SqlDbType.VarChar);
                        collection[7].Value = User.Birthday;

                        collection[8] = new SqlParameter("@UsersGender", SqlDbType.VarChar);
                        collection[8].Value = User.Gender;

                        collection[9] = new SqlParameter("@UsersMobileNumber", SqlDbType.VarChar);
                        collection[9].Value = User.MobileNumber;

                        collection[10] = new SqlParameter("@UsersCURP", SqlDbType.VarChar);
                        collection[10].Value = User.CURP;

                        collection[11] = new SqlParameter("@UsersImage", SqlDbType.VarChar);
                        collection[11].Value = User.Image;

                        User.Role = new ML.Role();

                        collection[12] = new SqlParameter("@RoleId", SqlDbType.TinyInt);
                        collection[12].Value = User.Role.IdRole;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result UpdateEF(ML.User User)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new DL_EF.HCardenasProgramcionNCapasEntities())
                {
                    int queryEF = cnn.UserUpdate(User.IdUser, User.FirstName, User.LastName, User.MotherLastName, User.Email, User.Password, User.PhoneNumber, User.PotalCode, User.UserName, DateTime.Parse(User.Birthday), User.Gender, User.MobileNumber, User.CURP, User.Image, User.Role.IdRole);

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

        public static ML.Result UpdateLINQ(ML.User User)
        {
            Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryLINKQ = (from tblUsers in cnn.Users
                                      where tblUsers.IdUser == User.IdUser
                                      select tblUsers).SingleOrDefault();

                    if (queryLINKQ != null)
                    {
                        queryLINKQ.FirstName = User.FirstName;
                        queryLINKQ.LastName = User.LastName;
                        queryLINKQ.MotherLastName = User.MotherLastName;
                        queryLINKQ.Email = User.Email;
                        queryLINKQ.Password = User.Password;
                        queryLINKQ.PhoneNumber = User.PhoneNumber;
                        queryLINKQ.PostalCode = User.PotalCode;
                        queryLINKQ.UserName = User.UserName;
                        queryLINKQ.Birthday = DateTime.Parse(User.Birthday);
                        queryLINKQ.Gender = User.Gender;
                        queryLINKQ.MobileNumber = User.MobileNumber;
                        queryLINKQ.CURP = User.CURP;
                        queryLINKQ.Image = User.Image;
                        queryLINKQ.IdRole = User.Role.IdRole;
                        cnn.SaveChanges();

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
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UserGetAll";
                    using (SqlCommand cmd = new SqlCommand(query,cnn))
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            result.Objects = new List<object>();
                            foreach (DataRow row in dt.Rows)
                            {
                                ML.User users = new ML.User();

                                users.IdUser = Int32.Parse(row[0].ToString());
                                users.FirstName = row[1].ToString();
                                users.LastName = row[2].ToString();
                                users.MotherLastName = row[3].ToString();
                                users.Email = row[2].ToString();
                                users.Password = row[3].ToString();
                                users.PhoneNumber = row[4].ToString();
                                users.PotalCode = row[5].ToString();
                                users.UserName = row[6].ToString();
                                users.Birthday = row[7].ToString();
                                users.Gender = row[8].ToString();
                                users.MobileNumber = row[9].ToString();
                                users.CURP = row[10].ToString();
                                users.Image = row[11].ToString();

                                users.Role = new ML.Role();
                                users.Role.IdRole = byte.Parse(row[12].ToString());
                                users.Role.Name = row[13].ToString();

                                result.Objects.Add(users);

                                //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                            }
                        }
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result GetAllQuery()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "SELECT UsersId, UsersName, UsersEmail, UsersPassword, UsersPhoneNumber, UsersPostalCode, UsersUserName, UsersBirthday, UsersGender, UsersMobileNumber, UsersCURP, UsersImage, RoleId FROM Users";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;


                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            result.Objects = new List<object>();
                            foreach (DataRow row in dt.Rows)
                            {
                                ML.User users = new ML.User();

                                users.IdUser = Int32.Parse(row[0].ToString());
                                users.FirstName = row[1].ToString();
                                users.LastName = row[1].ToString();
                                users.MotherLastName = row[1].ToString();
                                users.Email = row[2].ToString();
                                users.Password = row[3].ToString();
                                users.PhoneNumber = row[4].ToString();
                                users.PotalCode = row[5].ToString();
                                users.UserName = row[6].ToString();
                                users.Birthday = row[7].ToString();
                                users.Gender = row[8].ToString();
                                users.MobileNumber = row[9].ToString();
                                users.CURP = row[10].ToString();
                                users.Image = row[11].ToString();

                                users.Role = new ML.Role();
                                users.Role.IdRole = byte.Parse(row[12].ToString());



                                result.Objects.Add(users);

                                //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);
                            }
                        }
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result GetAllEF()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryEF = cnn.UserGetAll().ToList();

                    result.Objects = new List<object>();    

                    if (queryEF != null)
                    {
                        foreach (var row in queryEF)
                        {
                            ML.User users = new ML.User();

                            users.IdUser = row.IdUser;
                            users.FirstName = row.FirstName;
                            users.LastName = row.LastName;
                            users.MotherLastName = row.MotherLastName;
                            users.Email = row.Email;
                            users.Password = row.Password;
                            users.PhoneNumber = row.PhoneNumber;
                            users.PotalCode = row.PostalCode;
                            users.UserName = row.UserName;
                            users.Birthday = row.Birthday.ToString();
                            users.Gender = row.Gender;
                            users.MobileNumber = row.MobileNumber;
                            users.CURP = row.CURP;
                            users.Image = row.Image;

                            users.Role = new ML.Role();
                            users.Role.IdRole = row.IdRole;
                            users.Role.Name = row.RoleName;

                            result.Objects.Add(users);

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

        public static ML.Result GetAllLINKQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryLINKQ = (from tblUsers in cnn.Users
                                      join tblRoles in cnn.Roles on tblUsers.IdRole equals tblRoles.IdRole
                                      select new 
                                      { 
                                          IdUser = tblUsers.IdUser, 
                                          FirstName = tblUsers.FirstName, 
                                          LastName = tblUsers.LastName, 
                                          MotherLastName = tblUsers.MotherLastName, 
                                          Email = tblUsers.Email,
                                          Password = tblUsers.Password,
                                          PhoneNumber = tblUsers.PhoneNumber, 
                                          PostalCode = tblUsers.PostalCode, 
                                          UserName = tblUsers.UserName, 
                                          Birthday = tblUsers.Birthday, 
                                          Gender = tblUsers.Gender, 
                                          MobileNumber = tblUsers.MobileNumber,
                                          CURP = tblUsers.CURP,
                                          Image = tblUsers.Image,
                                          IdRole = tblUsers.IdRole,
                                          RoleName = tblRoles.Name,
                                      }).ToList();

                    result.Objects = new List<object>();

                    foreach (var row in queryLINKQ)
                    {
                        ML.User users = new ML.User();
                        users.IdUser = row.IdUser;
                        users.FirstName = row.FirstName;
                        users.LastName = row.LastName;
                        users.MotherLastName = row.MotherLastName;
                        users.Email = row.Email;
                        users.Password = row.Password;
                        users.PhoneNumber = row.PhoneNumber;
                        users.PotalCode = row.PostalCode;
                        users.UserName = row.UserName;
                        users.Birthday = row.Birthday.ToString("dd/MMM/yyyy");
                        users.Gender = row.Gender;
                        users.MobileNumber = row.MobileNumber;
                        users.CURP = row.CURP;
                        users.Image = row.Image;

                        users.Role = new ML.Role();
                        users.Role.IdRole = row.IdRole;
                        users.Role.Name = row.RoleName;

                        result.Objects.Add(users);
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

        public static ML.Result GetById(int UserId)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "UsersById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsers", SqlDbType.Int);
                        collection[0].Value = UserId;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                ML.User users = new ML.User();
                                DataRow row = dt.Rows[0];

                                users.IdUser = Int32.Parse(row[0].ToString());
                                users.FirstName = row[1].ToString();
                                users.LastName = row[1].ToString();
                                users.MotherLastName = row[1].ToString();
                                users.Email = row[2].ToString();
                                users.Password = row[3].ToString();
                                users.PhoneNumber = row[4].ToString();
                                users.PotalCode = row[5].ToString();
                                users.UserName = row[6].ToString();
                                users.Birthday = row[7].ToString();
                                users.Gender = row[8].ToString();
                                users.MobileNumber = row[9].ToString();
                                users.CURP = row[10].ToString();
                                users.Image = row[11].ToString();

                                users.Role = new ML.Role();
                                users.Role.IdRole = byte.Parse(row[12].ToString());

                                result.Object = users;
                            }

                            //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);                            
                        }

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result GetByIdQuery(int UserId)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection cnn = new SqlConnection(DL.Connection.GetConnection()))
                {
                    string query = "SELECT UserId, UsersName, UsersEmail, UsersPassword, UsersPhoneNumber, UsersPostalCode, UsersUserName, UsersBirthday, UsersGender, UsersMobileNumber, UsersCURP, UsersImage, RoleId FROM Users WHERE UsersId = @UsersId";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@UsersId", SqlDbType.Int);
                        collection[0].Value = UserId;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                ML.User users = new ML.User();
                                DataRow row = dt.Rows[0];

                                users.IdUser = Int32.Parse(row[0].ToString());
                                users.FirstName = row[1].ToString();
                                users.LastName = row[1].ToString();
                                users.MotherLastName = row[1].ToString();
                                users.Email = row[2].ToString();
                                users.Password = row[3].ToString();
                                users.PhoneNumber = row[4].ToString();
                                users.PotalCode = row[5].ToString();
                                users.UserName = row[6].ToString();
                                users.Birthday = row[7].ToString();
                                users.Gender = row[8].ToString();
                                users.MobileNumber = row[9].ToString();
                                users.CURP = row[10].ToString();
                                users.Image = row[11].ToString();

                                users.Role = new ML.Role();
                                users.Role.IdRole = byte.Parse(row[12].ToString());

                                result.Object = users;
                            }

                            //Console.WriteLine(row["UsersId"] + ",  " + row["UsersName"] + ",  " + row["UsersEmail"] + ",  " + row["UsersPassword"] + ",  " + row["UsersPhoneNumber"] + ",  " + row["UsersPostalCode"]);                            
                        }

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
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

        public static ML.Result GetByIdEF(int UserId)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryEF = cnn.UserById(UserId).FirstOrDefault();
 

                    if (queryEF != null)
                    {
                        ML.User users = new ML.User();
                        users.IdUser =queryEF.IdUser;
                        users.FirstName = queryEF.FirstName;
                        users.LastName = queryEF.LastName;
                        users.MotherLastName = queryEF.MotherLastName;
                        users.Email = queryEF.Email;
                        users.Password = queryEF.Password;
                        users.PhoneNumber = queryEF.PhoneNumber;
                        users.PotalCode = queryEF.PostalCode;
                        users.UserName = queryEF.UserName;
                        users.Birthday = queryEF.Birthday.ToString();
                        users.Gender = queryEF.Gender;
                        users.MobileNumber = queryEF.MobileNumber;
                        users.CURP = queryEF.CURP;
                        users.Image = queryEF.Image;

                        users.Role = new ML.Role();
                        users.Role.IdRole = queryEF.IdRole;
                        users.Role.Name = queryEF.RoleName;

                        result.Object = users;
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

        public static ML.Result GetByIdLINKQ(int UserId)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.HCardenasProgramcionNCapasEntities cnn = new HCardenasProgramcionNCapasEntities())
                {
                    var queryLINKQ = (from tblUsers in cnn.Users
                                      join tblRoles in cnn.Roles on tblUsers.IdRole equals tblRoles.IdRole
                                      where tblUsers.IdUser == UserId
                                      select new
                                      {
                                          IdUser = tblUsers.IdUser,
                                          FirstName = tblUsers.FirstName,
                                          LastName = tblUsers.LastName,
                                          MotherLastName = tblUsers.MotherLastName,
                                          Email = tblUsers.Email,
                                          Password = tblUsers.Password,
                                          PhoneNumber = tblUsers.PhoneNumber,
                                          PostalCode = tblUsers.PostalCode,
                                          UserName = tblUsers.UserName,
                                          Birthday = tblUsers.Birthday,
                                          Gender = tblUsers.Gender,
                                          MobileNumber = tblUsers.MobileNumber,
                                          CURP = tblUsers.CURP,
                                          Image = tblUsers.Image,
                                          IdRole = tblUsers.IdRole,
                                          RoleName = tblRoles.Name,
                                      }).FirstOrDefault();

                    if (queryLINKQ != null)
                    {
                        ML.User users = new ML.User();
                        users.IdUser = queryLINKQ.IdUser;
                        users.FirstName = queryLINKQ.FirstName;
                        users.LastName = queryLINKQ.LastName;
                        users.MotherLastName = queryLINKQ.MotherLastName;
                        users.Email = queryLINKQ.Email;
                        users.Password = queryLINKQ.Password;
                        users.PhoneNumber = queryLINKQ.PhoneNumber;
                        users.PotalCode = queryLINKQ.PostalCode;
                        users.UserName = queryLINKQ.UserName;
                        users.Birthday = queryLINKQ.Birthday.ToString("dd/MMM/yyyy");
                        users.Gender = queryLINKQ.Gender;
                        users.MobileNumber = queryLINKQ.MobileNumber;
                        users.CURP = queryLINKQ.CURP;
                        users.Image = queryLINKQ.Image;

                        users.Role = new ML.Role();
                        users.Role.IdRole = queryLINKQ.IdRole;
                        users.Role.Name = queryLINKQ.RoleName;

                        result.Object = users;
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
