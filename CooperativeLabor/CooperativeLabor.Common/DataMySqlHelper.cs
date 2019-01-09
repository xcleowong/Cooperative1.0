using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

//create by wcy
//DataBase Operation 

namespace CooperativeLabor.Common
{
    public class MySqlHelper
    {
        private static string strcn = ConfigurationManager.ConnectionStrings["MsConnectionStr"].ConnectionString;

        #region 根据SQL查出DataTable对象
        public static System.Data.DataTable getDataTable(string Sql)
        {
            // string strcn = ConfigurationManager.AppSettings["SqlConnString"];
            MySqlConnection connect = new MySqlConnection(strcn);
            DataTable dataTable = new DataTable();

            try
            {
                connect.Open();
                MySqlDataAdapter dap = new MySqlDataAdapter(Sql, strcn);
                dap.Fill(dataTable);

            }
            catch (System.Exception e)
            {
                dataTable = null;
                throw e;
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                connect = null;
            }
            return dataTable;
        }

        //执行一个Sql语句[如插入、更新、删除]
        //Create By Wcy
        //Create Date:2017-08-24    
        public static int ExecuteNonQuery(string Sql)
        {
            // string strcn = ConfigurationManager.AppSettings["SqlConnString"];                  
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            MySqlCommand Cmd = new MySqlCommand(Sql, gCn);
            try
            {
                Cmd.Prepare();
                int iResult = Cmd.ExecuteNonQuery();
                return iResult;
            }
            catch (System.Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
                Cmd.Dispose();
                Cmd = null;
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="strSqlList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList strSqlList)
        {
            //string strcn = ConfigurationManager.AppSettings["SqlConnString"];
            using (MySqlConnection conn = new MySqlConnection(strcn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();



                cmd.Connection = conn;
                MySqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    for (int n = 0; n < strSqlList.Count; n++)
                    {
                        string strsql = strSqlList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    trans.Rollback();
                    throw e;
                }
                finally
                {
                    conn.Close();
                    cmd.Dispose();
                    trans.Dispose();
                }
            }
        }


        //执行一个Sql语句返回一个值
        //Create By Wcy
        //Create Date:2017-08-24    
        public static object ExecuteScalar(string Sql)
        {
            //string strcn = ConfigurationManager.AppSettings["SqlConnString"];
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            MySqlCommand Cmd = new MySqlCommand(Sql, gCn);
            try
            {
                Cmd.Prepare();
                return Cmd.ExecuteScalar();
            }
            catch (System.Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
                Cmd.Dispose();
                Cmd = null;
            }
        }


        //分页存储过程   
        public static DataTable sp_page(string sql, int curIndex, int page_Size, out int rowCount)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "UP_UsePaging";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;

                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("usersql", MySqlDbType.VarChar, 4000),
                    new MySqlParameter("currentPage", MySqlDbType.Int32),
                    new MySqlParameter("pageSize", MySqlDbType.Int32),
                    new MySqlParameter("pageCount", MySqlDbType.Int32),
                    };

                parameters[0].Value = sql;
                parameters[1].Value = curIndex;
                parameters[2].Value = page_Size;
                parameters[3].Direction = ParameterDirection.Output;

                cmd.Parameters.AddRange(parameters);

                MySqlDataAdapter dap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                rowCount = Convert.ToInt32(parameters[3].Value);
                dap.Dispose();
                return dt;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }

        public static DataTable getStudent()
        {
            // string strcn = ConfigurationManager.AppSettings["SqlConnString"];
            MySqlConnection gCn = new MySqlConnection(strcn);
            string sql = "sp_page2('select * from student',1,2,@tt);";
            MySqlCommand Cmd = new MySqlCommand(sql, gCn);

            try
            {
                gCn.Open();
                Cmd.ExecuteNonQuery(); //执行存储过程

                //显示数据
                MySqlDataAdapter dap = new MySqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dap.Dispose();
                return dt;

            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;

            }


        }
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="studentinfo11Name"></param>
        /// <param name="studentinfo11Gender"></param>
        /// <param name="studentinfo11Dept"></param>
        /// <param name="studentinfo11Birthday"></param>
        /// <param name="studentinfo11Address"></param>
        /// <returns></returns>
        public static int up_AddStudent(string studentinfo11Name, string studentinfo11Gender, string studentinfo11Dept, string studentinfo11Birthday, string
           studentinfo11Address)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "UP_AddStudentInfo11";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;

                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("studentName", MySqlDbType.VarChar),
                    new MySqlParameter("Gender", MySqlDbType.VarChar),
                    new MySqlParameter("Dept", MySqlDbType.VarChar),
                    new MySqlParameter("Birthday",MySqlDbType.VarChar),
                    new MySqlParameter("Address", MySqlDbType.VarChar),
                    };

                parameters[0].Value = studentinfo11Name;
                parameters[1].Value = studentinfo11Gender;
                parameters[2].Value = studentinfo11Dept;
                parameters[3].Value = studentinfo11Birthday;
                parameters[4].Value = studentinfo11Address;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="studentinfo11Name"></param>
        /// <param name="studentinfo11Gender"></param>
        /// <param name="studentinfo11Dept"></param>
        /// <param name="studentinfo11Birthday"></param>
        /// <param name="studentinfo11Address"></param>
        /// <returns></returns>
        public static int UP_Updatestudent(string studentinfo11Name, string studentinfo11Gender, string studentinfo11Dept, string studentinfo11Birthday, string
           studentinfo11Address, int StudentInfo11ID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "UP_Updatestudentinfo11";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("studentName", MySqlDbType.VarChar),
                    new MySqlParameter("Gender", MySqlDbType.VarChar),
                    new MySqlParameter("Dept", MySqlDbType.VarChar),
                    new MySqlParameter("Birthday",MySqlDbType.VarChar),
                    new MySqlParameter("Address", MySqlDbType.VarChar),
                    new MySqlParameter("ID",MySqlDbType.Int32)
                    };
                parameters[5].Value = StudentInfo11ID;
                parameters[0].Value = studentinfo11Name;
                parameters[1].Value = studentinfo11Gender;
                parameters[2].Value = studentinfo11Dept;
                parameters[3].Value = studentinfo11Birthday;
                parameters[4].Value = studentinfo11Address;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 根据ID删除学生信息
        /// </summary>
        /// <param name="StudentInfo11ID"></param>
        /// <returns></returns>
        public static int UP_Deletestudent(int StudentInfo11ID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "UP_Deletestudentinfo11";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                   new MySqlParameter("ID",MySqlDbType.Int32)
                    };
                parameters[0].Value = StudentInfo11ID;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="EmpInformationName"></param>
        /// <param name="EmpInformationGender"></param>
        /// <param name="EmpInformationRemark"></param>
        /// <returns></returns>
        public static int up_AddEmpInformation(string EmpInformationName, string EmpInformationGender, string EmpInformationRemark)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_AddEmpInformation";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;

                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("EmpName", MySqlDbType.VarChar),
                    new MySqlParameter("EmpGender", MySqlDbType.VarChar),
                    new MySqlParameter("EmpRemark", MySqlDbType.VarChar)
                    };

                parameters[0].Value = EmpInformationName;
                parameters[1].Value = EmpInformationGender;
                parameters[2].Value = EmpInformationRemark;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="EmpInformationName"></param>
        /// <param name="EmpInformationGender"></param>
        /// <param name="EmpInformationRemark"></param>
        /// <param name="EmpInformationID"></param>
        /// <returns></returns>
        public static int up_UpdateEmpInformation(string EmpInformationName, string EmpInformationGender, string EmpInformationRemark, int EmpInformationID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_UpdateEmpInformation";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("EmpName", MySqlDbType.VarChar),
                    new MySqlParameter("EmpGender", MySqlDbType.VarChar),
                    new MySqlParameter("EmpRemark", MySqlDbType.VarChar),
                    new MySqlParameter("EmpID", MySqlDbType.Int32)
                    };
                parameters[0].Value = EmpInformationName;
                parameters[1].Value = EmpInformationGender;
                parameters[2].Value = EmpInformationRemark;
                parameters[3].Value = EmpInformationID;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 根据ID删除员工信息
        /// </summary>
        /// <param name="EmpInformationID"></param>
        /// <returns></returns>
        public static int up_DeleteEmpInformation(int EmpInformationID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_DeleteEmpInformation";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("EmpID", MySqlDbType.Int32)
                    };
                parameters[0].Value = EmpInformationID;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="ScholasticName"></param>
        /// <param name="ScholasticAge"></param>
        /// <param name="ScholasticGender"></param>
        /// <returns></returns>
        public static int up_AddAddscholastic(string ScholasticName, string ScholasticAge, string ScholasticGender)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_AddScholastic";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;

                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("studentName", MySqlDbType.VarChar),
                    new MySqlParameter("studentAge", MySqlDbType.VarChar),
                    new MySqlParameter("studentGender", MySqlDbType.VarChar)
                    };

                parameters[0].Value = ScholasticName;
                parameters[1].Value = ScholasticAge;
                parameters[2].Value = ScholasticGender;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="ScholasticName"></param>
        /// <param name="ScholasticAge"></param>
        /// <param name="ScholasticGender"></param>
        /// <param name="ScholasticID"></param>
        /// <returns></returns>
        public static int up_UpdateUpdatescholastic(string ScholasticName, string ScholasticAge, string ScholasticGender, int ScholasticID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_UpdateScholastic";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("studentName", MySqlDbType.VarChar),
                    new MySqlParameter("studentAge", MySqlDbType.VarChar),
                    new MySqlParameter("studentGender", MySqlDbType.VarChar),
                    new MySqlParameter("studentID", MySqlDbType.Int32)
                    };
                parameters[0].Value = ScholasticName;
                parameters[1].Value = ScholasticAge;
                parameters[2].Value = ScholasticGender;
                parameters[3].Value = ScholasticID;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }
        /// <summary>
        /// 根据ID删除学生信息
        /// </summary>
        /// <param name="ScholasticID"></param>
        /// <returns></returns>
        public static int up_DeleteDeletescholastic(int ScholasticID)
        {
            MySqlConnection gCn = new MySqlConnection(strcn);

            try
            {
                gCn.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(); //调用指定的存储过程
                cmd.CommandText = "up_DeleteScholastic";
                cmd.CommandType = CommandType.StoredProcedure;  //指明类型
                cmd.Connection = gCn;
                cmd.Parameters.Clear();
                MySqlParameter[] parameters = {
                    new MySqlParameter("studentID", MySqlDbType.Int32)
                    };
                parameters[0].Value = ScholasticID;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
                gCn.Close();
                gCn.Dispose();
                gCn = null;
            }

        }

        #endregion
    }
}
