using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AudienceResponse.CMN;

namespace AudienceResponse.DAL
{
    public class DALParticipants
    {
        public int insertParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " INSERT INTO [tblParticipants] " +
                " ( " +
                "  SysID," +
                "  SeatRowNo," +
                "  RankID," +
                "  Initials," +
                "  Name," +
                "  Titles," +
                "  CountryID," +
                "  ParticipantImage," +
                "  Status,"+
                "  userid," +
                "  IDImage)" +
                " VALUES " +
                " ( " +
                "  @SysID," +
                "  @SeatRowNo," +
                "  @RankID," +
                "  @Initials," +
                "  @Name," +
                "  @Titles," +
                "  @CountryID," +
                "  @ParticipantImage," +
                "  @Status," +
                "  @userid," +
                "  @IDImage) ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.Parameters.AddWithValue("@SeatRowNo", oCMNParticipants.SeatRowNo);
                oSqlCommand.Parameters.AddWithValue("@RankID", oCMNParticipants.RankID);
                oSqlCommand.Parameters.AddWithValue("@Initials", oCMNParticipants.Initials);
                oSqlCommand.Parameters.AddWithValue("@Name", oCMNParticipants.Name);
                oSqlCommand.Parameters.AddWithValue("@Titles", oCMNParticipants.Titles);
                oSqlCommand.Parameters.AddWithValue("@CountryID", oCMNParticipants.CountryID);
                oSqlCommand.Parameters.AddWithValue("@ParticipantImage", oCMNParticipants.ParticipantImage);
                oSqlCommand.Parameters.AddWithValue("@Status", oCMNParticipants.Status);
                oSqlCommand.Parameters.AddWithValue("@userid", oCMNParticipants.UserID);
                oSqlCommand.Parameters.AddWithValue("@IDImage", oCMNParticipants.IDImage);

                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                return oSqlCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            int updateCount;
            string sqlQuery;
            SqlCommand oSqlCommand;
            try
            {
                sqlQuery = " UPDATE [tblParticipants] SET" +
                "  SeatRowNo=@SeatRowNo," +
                "  RankID=@RankID," +
                "  Initials=@Initials," +
                "  Name=@Name," +
                "  Titles=@Titles," +
                "  CountryID=@CountryID," +
                "  ParticipantImage=@ParticipantImage, " +
                "  userid=@userid, " +
                "  Status=@Status, " +
                "  IDImage=@IDImage " +
                "  WHERE SysID=@SysID";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.Parameters.AddWithValue("@SeatRowNo", oCMNParticipants.SeatRowNo);
                oSqlCommand.Parameters.AddWithValue("@RankID", oCMNParticipants.RankID);
                oSqlCommand.Parameters.AddWithValue("@Initials", oCMNParticipants.Initials);
                oSqlCommand.Parameters.AddWithValue("@Name", oCMNParticipants.Name);
                oSqlCommand.Parameters.AddWithValue("@Titles", oCMNParticipants.Titles);
                oSqlCommand.Parameters.AddWithValue("@Status", oCMNParticipants.Status);
                oSqlCommand.Parameters.AddWithValue("@CountryID", oCMNParticipants.CountryID);
                oSqlCommand.Parameters.AddWithValue("@ParticipantImage", oCMNParticipants.ParticipantImage);               
                oSqlCommand.Parameters.AddWithValue("@userid", oCMNParticipants.UserID);
                oSqlCommand.Parameters.AddWithValue("@IDImage", oCMNParticipants.IDImage);
                
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deleteParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [tblParticipants] SET" +
                "  Status=2" +
                "  WHERE SysID=@SysID";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateqst(string userid, DBHandle oDBHandle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            int updateCount;
            try
            {
                sqlQuery = " UPDATE [tblQuests] SET" +
                "  status=2";

                oSqlCommand = new SqlCommand();
                
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                updateCount = oSqlCommand.ExecuteNonQuery();

                return updateCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable selectParticipantDataByCardID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT  P.SysID,P.SeatRowNo, P.CardID ,R.ShortName, P.Initials, P.Name,P.Titles, C.CountryName,'0' AS Flag,b.qst,P.userid " +
                           " FROM tblCountry C INNER JOIN tblParticipants P ON C.CountryID = P.CountryID INNER JOIN tblRanks R ON P.RankID = R.RankID  left JOIN tblQuests b ON P.userid = b.userids WHERE p.Status=1 AND b.status=1 order by b.id desc ";

                oSqlCommand = new SqlCommand();
               // oSqlCommand.Parameters.AddWithValue("@userid", oCMNParticipants.UserID);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectParticipantDataBySysID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();

            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT  P.SysID,P.SeatRowNo, P.CardID ,R.ShortName,R.LongName, P.Initials, P.Name,P.Titles, C.CountryName, P.ParticipantImage,P.IDImage,b.qst " +
                           " FROM tblCountry C INNER JOIN tblParticipants P ON C.CountryID = P.CountryID INNER JOIN tblRanks R ON P.RankID = R.RankID left JOIN tblQuests b ON P.userid = b.userids WHERE P.SysID=@SysID AND p.Status=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectAllParticipantData(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT P.SysID,P.SeatRowNo, P.CardID,R.ShortName, P.Initials, P.Name,P.Titles, C.CountryName,b.qst  ,p.userid " +
                           " FROM tblCountry C INNER JOIN tblParticipants P ON C.CountryID = P.CountryID INNER JOIN tblRanks R ON P.RankID = R.RankID left JOIN tblQuests b ON P.userid = b.userids WHERE p.Status=1 ";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable selectSeniorParticipantData(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT P.SysID,P.SeatRowNo, P.CardID ,R.ShortName, P.Initials, P.Name,P.Titles, C.CountryName,p.userid,b.qst" +
                           " FROM tblCountry C INNER JOIN tblParticipants P ON C.CountryID = P.CountryID LEFT JOIN tblRanks R ON P.RankID = R.RankID INNER JOIN tblQuests b ON P.userid = b.userids WHERE p.Status=1 " + 
                           " AND R.Seniority IN(0,1,2,3,4,5,6,100,34,35,36)";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public DataTable selectRanks(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT RankID,LongName FROM tblRanks ORDER BY RankTypeID,Seniority";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectCountries(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT CountryID,CountryName FROM tblCountry";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getNewParticipantID(DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = " SELECT MAX(SysID)+1 AS SysID FROM tblParticipants";

                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable selectAllBySysID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            string sqlQuery;
            DataTable oDataTable = new DataTable();
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SELECT * FROM tblParticipants WHERE SysID=@SysID";

                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@SysID", oCMNParticipants.SysID);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDBHandle.GetConnection();
                oSqlCommand.Transaction = oDBHandle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
