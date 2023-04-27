using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;



namespace AudienceResponse.CMN
{
    public class DBHandle

    {
        private SqlConnection dbCon;
        private SqlTransaction dbTrans;

        private void CreateConnection() 
        {

            string dbConString = @"Data Source=.\MSSQLSERVER2014;Initial Catalog=AUDIENCE_RESPONSE_SYS;User ID=sa;Password=123";              

            dbCon = new SqlConnection(dbConString);
        }

        public void OpenConnection()
        {
            if (dbCon == null)
            {
                CreateConnection();
            }

            if (dbCon.State==ConnectionState.Closed)
            {
                dbCon.Open();
            }           

        }

        public void CloseConnection()
        {
            if (dbCon.State != ConnectionState.Closed)
            {
                dbCon.Close();
            }

        }

        public void BeginTransaction()
        {
            dbTrans = dbCon.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbTrans.Commit();

        }

        public void RollbackTransaction()
        {
            if (dbTrans != null)
            {
                dbTrans.Rollback();
            }
        }

        public  SqlConnection GetConnection()
        {
            return dbCon;
        }

        public  SqlTransaction GetTransaction()
        {
            return dbTrans;
        }

        public String ExicuteAnyCommand(String CmdStr, string FnNaame)
        {

            SqlCommand Mycom = new SqlCommand();
            CreateConnection();
            Mycom.CommandText = CmdStr;
            Mycom.Connection = GetConnection();
            if (Mycom.Connection.State == ConnectionState.Closed)
                Mycom.Connection.Open();
            try
            {

                int Res = Mycom.ExecuteNonQuery();
                if (Res > 0)
                    return "True";
                else
                    return "Effected Row Count is " + Res.ToString() + " ,Warning !! Operation Not Successfull !!";
            }
            catch (Exception ex)
            {
                WriteToError(ex.Message, FnNaame);
                return ex.Message;
            }

        }

        public string GetDataTable(String CmdStr, string FnNaame, out DataTable Mytb)
        {
            SqlCommand Mycom = new SqlCommand();
            Mytb = new DataTable();
            Mycom.CommandText = CmdStr;

            CreateConnection();

            Mycom.Connection = GetConnection();

           
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter(Mycom);

                myda.Fill(Mytb);
                if (Mytb != null)
                {
                    if (Mytb.Rows.Count > 0)
                        return "True";
                    else
                        return "False";
                }
                else
                    return "False";
            }
            catch (Exception ex)
            {
                WriteToError(ex.Message, FnNaame);
                return ex.Message;
            }
        }

        public DataTable GetDataTable(String CmdStr, string FnNaame)
        {
            SqlCommand Mycom = new SqlCommand();
            DataTable Mytb = new DataTable();
            Mycom.CommandText = CmdStr;
            CreateConnection();
            Mycom.Connection = GetConnection();
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter(Mycom);

                myda.Fill(Mytb);
                
                if (Mytb != null)
                {
                    if (Mytb.Rows.Count > 0)
                        return Mytb;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                WriteToError(ex.Message, FnNaame);
                return Mytb;
            }
        }
        
        public bool ExistIntable(string Sqlstring)
        {
            DataRow Myrow = GetDataRow(Sqlstring, "ExistIntable");
            try
            {
                if (Myrow != null)
                {
                    if (string.IsNullOrEmpty(Myrow[0].ToString()) == false)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataRow GetDataRow(String CmdStr, string FnNaame)
        {
            SqlCommand Mycom = new SqlCommand();
            DataTable Mytb = new DataTable();
            Mycom.CommandText = CmdStr;
            SqlTransaction MyTras;
            CreateConnection(); 
            SqlConnection Myconnection = new SqlConnection();
            Myconnection= dbCon;

            if (Myconnection.State == ConnectionState.Closed)
                Myconnection.Open();
            Mycom.Connection = Myconnection;
           
           try
            {
                SqlDataAdapter myda = new SqlDataAdapter(Mycom);
                myda.Fill(Mytb);
                MyTras = Myconnection.BeginTransaction();
                if (Mytb.Rows != null)
                {
                    MyTras.Commit();
                    CloseConnection(); 
                    if (Mytb.Rows.Count > 0)
                    {   
                      
                        return Mytb.Rows[0]; 
                    }
                    else
                        return null;
                }
                else
                {
                    MyTras.Rollback();
                    CloseConnection(); 
                    return null;
                }
            }
            catch (Exception ex)
            {
                WriteToError(ex.Message, FnNaame);
                return null;
            }
        }

        public DataColumn GetDataColumn(String CmdStr, string FnNaame)
        {
            SqlCommand Mycom = new SqlCommand();
            DataTable Mytb = new DataTable();
            DataColumn mycol = new DataColumn();
            Mycom.CommandText = CmdStr;
            CreateConnection();
            Mycom.Connection = GetConnection();
            try
            {
                SqlDataAdapter myda = new SqlDataAdapter(Mycom);
                myda.Fill(Mytb);
                if (Mytb.Rows != null)
                {
                    mycol = Mytb.Columns[0];
                    return mycol;
                }
            }
            catch (Exception ex)
            {
                WriteToError(ex.Message, FnNaame);
                return mycol;
            }
            return mycol;
        }

        public void WriteToError(String Errmsg, String FunctioName)
        {
            String str1;

            Errmsg = Errmsg.Replace("'", "-");
            str1 = "Insert INTO tblErrorLog (Ermsg,FnNmae,ErDate) "
            + " Values ('" + Errmsg + "','" + FunctioName + "',CurDate())";
            try
            {
             
            }
            catch (Exception)
            {


            }
        }

        public void CloseDB()
        {
            if (GetConnection().State == ConnectionState.Open)
            {
                GetConnection().Dispose();
            }
        }

        public string Decrypt(string value)
        {
            string retVal = null;

            byte[] decBytes = Convert.FromBase64String(value);
            retVal = System.Text.Encoding.Unicode.GetString(decBytes);

            return retVal;
        }
    }
}