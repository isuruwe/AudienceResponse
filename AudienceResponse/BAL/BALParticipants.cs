using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AudienceResponse.CMN;
using AudienceResponse.DAL;

namespace AudienceResponse.BAL
{
    public class BALParticipants
    {
        public int insertParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int insertCount;

            try
            {                
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                insertCount=oDALParticipants.insertParticipantData(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return insertCount;
        }
        public int updateParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {                
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updateParticipantData(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }

        
             public int updateqst(string usrid, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.updateqst(usrid, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public int deleteParticipantData(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            int updateCount;

            try
            {
                bool newDBHandle = false;

                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                updateCount = oDALParticipants.deleteParticipantData(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return updateCount;
        }
        public DataTable selectParticipantDataByCardID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectParticipantDataByCardID(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectParticipantDataBySysID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectParticipantDataBySysID(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectAllParticipantData(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectAllParticipantData(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectSeniorParticipantData(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectSeniorParticipantData(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectRanks(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectRanks(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public DataTable selectCountries(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectCountries(oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }
        public int getNewParticipantID(DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.getNewParticipantID(oDBHandle);

                if (oDataTable.Rows.Count>0)
                {
                    return (int)oDataTable.Rows[0][0];
                }
                else
                {
                    return 1;
                }

                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
        }
        public DataTable selectAllBySysID(CMNParticipants oCMNParticipants, DBHandle oDBHandle)
        {
            DALParticipants oDALParticipants = new DALParticipants();
            DataTable oDataTable = new DataTable();
            try
            {
                bool newDBHandle = false;
                if (oDBHandle == null)
                {
                    oDBHandle = new DBHandle();
                    oDBHandle.OpenConnection();
                    oDBHandle.BeginTransaction();
                    newDBHandle = true;
                }
                oDataTable = oDALParticipants.selectAllBySysID(oCMNParticipants, oDBHandle);
                if (newDBHandle)
                {
                    oDBHandle.CommitTransaction();
                    oDBHandle.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                oDBHandle.RollbackTransaction();
                oDBHandle.CloseConnection();
                throw ex;
            }
            return oDataTable;
        }

    }
}
