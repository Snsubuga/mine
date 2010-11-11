using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using HRMS.DBUtilities;

namespace DataMapper
{
    public class ReturnedMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_ALL = "SELECT * FROM Returned";
        private const string SQL_SELECT_RETURN = "SELECT * FROM Returned WHERE ReturnId = @returnid";
        private const string SQL_INSERT_RETURN = "INSERT INTO Returned VALUES(@returnid, @itemid, @quantityreturned, @returndate, @returnedby, @receivedby, @returnreason)";
        private const string SQL_UPDATE_RETURN = "UPDATE Returned SET ItemId = @itemid, QuantityReturned = @quantityreturned, ReturnDate = @returndate, ReturnedBy = @returnedby, ReceivedBy = @receivedby, ReturnReason = @returnreason WHERE ReturnId = @returnid";
        private const string SQL_DELETE_RETURN = "DELETE FROM Returned WHERE ReturnId = @returnid";
        private const string PARAM_RETURNID = "@returnid";
        private const string PARAM_ITEMID = "@itemid";
        private const string PARAM_QTYRET = "@quantityreturned";
        private const string PARAM_RETDATE = "@returndate";
        private const string PARAM_RETBY = "@returnedby";
        private const string PARAM_RECBY = "@receivedby";
        private const string PARAM_RETRZN = "@returnreason";
        #endregion

        #region PRIVATE CONSTRUCTOR
        private ReturnedMapper()
        {
        }
        #endregion

        #region PUBLIC METHODS
        public IList<ReturnedInfo> GetAllReturns()
        {
            IList<ReturnedInfo> allreturns = new List<ReturnedInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ALL, null))
            {
                while(rdr.Read())
                {
                    ReturnedInfo retrn = new ReturnedInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6));

                    allreturns.Add(retrn);
                }
            }
            return allreturns;
        }
        public ReturnedInfo GetReturn(string returnid)
        {
            ReturnedInfo retn = null;
            SqlParameter param_retnid = new SqlParameter(PARAM_RETURNID,returnid);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_RETURN, param_retnid))
            {
                while (rdr.Read())
                {
                    retn = new ReturnedInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6));
                }
            }
            return retn;
        }
        public void DeleteReturn(ReturnedInfo returnobj)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_RETURN, CreateParameters(returnobj));
        }
        public void InsertReturn(ReturnedInfo returnobj)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_RETURN, CreateParameters(returnobj));
        }
        public void UpdateReturn(ReturnedInfo returnobj)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_RETURN, CreateParameters(returnobj));
        }
        #endregion

        #region UTILITIES
        private static ReturnedMapper instance = new ReturnedMapper();
        public static ReturnedMapper GetInstance()
        {
            return instance;
        }
        private SqlParameter[] CreateParameters(ReturnedInfo returnobj)
        {
            SqlParameter param_returnid = new SqlParameter(PARAM_RETURNID,returnobj.ReturnId);
            SqlParameter param_itemid = new SqlParameter(PARAM_ITEMID,returnobj.ItemId);
            SqlParameter param_qtyreturned = new SqlParameter(PARAM_QTYRET,returnobj.QuantityReturned);
            SqlParameter param_returndate = new SqlParameter(PARAM_RETDATE,returnobj.ReturnDate);
            SqlParameter param_returnedby = new SqlParameter(PARAM_RETBY,returnobj.ReturnedBy);
            SqlParameter param_receivedby = new SqlParameter(PARAM_RECBY,returnobj.ReceivedBy);
            SqlParameter param_returnreason = new SqlParameter(PARAM_RETRZN,returnobj.ReturnReason);

            return new SqlParameter[] {param_returnid,param_itemid,param_qtyreturned,param_returndate,param_returnedby, param_receivedby,param_returnreason };
        }
        #endregion
    }
}
