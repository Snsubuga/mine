using System;
using System.Collections.Generic;
using System.Text;
using HRMS.DBUtilities;
using Model;
using System.Data.SqlClient;

namespace DataMapper
{
    public class ReceiveMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_ALL = "SELECT * FROM Receive";
        private const string SQL_SELECT_REC = "SELECT * FROM Receive where ReceiveId = @receiveid";
        private const string SQL_INSERT_REC = "INSERT INTO Receive VALUES(@receiveid,@itemid, @receivedqty, @receiveddate, @receivedby)";
        private const string SQL_DELETE_REC = "DELETE FROM Receive WHERE ReceiveId = @receiveid";
        private const string SQL_UPDATE_REC = "UPDATE Receive SET ItemId = @itemid, ReceivedQuantity = @receivedqty, ReceivedDate = @receiveddate, ReceivedBy = @receivedby WHERE ReceiveId = @receiveid";
        private const string PARAM_RECID = "@receiveid";
        private const string PARAM_ITEMID = "@itemid";
        private const string PARAM_RECQTY = "@receivedqty";
        private const string PARAM_RECDATE = "@receiveddate";
        private const string PARAM_RECBY = "@receivedby";
      
        #endregion

        #region PRIVATE CONSTRUCTOR
        private ReceiveMapper()
        {
        }
        #endregion

        #region PUBLIC METHODS
        public IList<ReceiveInfo> GetAllReceived()
        {
            IList<ReceiveInfo> receives = new List<ReceiveInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ALL, null))
            {
                while (rdr.Read())
                {
                    ReceiveInfo receive = new ReceiveInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4));
                       

                    receives.Add(receive);
                }
            }
            return receives;
        }
        public ReceiveInfo GetReceive(string receiveid)
        {
            ReceiveInfo receive = null;
            SqlParameter param_receiveid = new SqlParameter(PARAM_RECID, receiveid);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_REC, param_receiveid))
            {
                while (rdr.Read())
                {
                    receive = new ReceiveInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4));
                       
                }
            }
            return receive;
        }
        public void DeleteReceive(ReceiveInfo receive)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_REC, CreateParameters(receive));
        }
        public void AddReceive(ReceiveInfo receive)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_REC, CreateParameters(receive));
        }
        public void UpdateReceive(ReceiveInfo receive)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_REC, CreateParameters(receive));
        }
        #endregion

        #region UTILITIES
        private static ReceiveMapper instance = new ReceiveMapper();
        public static ReceiveMapper GetInstance()
        {
            return instance;
        }
        private SqlParameter[] CreateParameters(ReceiveInfo receive)
        {
            SqlParameter param_recid = new SqlParameter(PARAM_RECID,receive.ReceiveId);
            SqlParameter param_itemid = new SqlParameter(PARAM_ITEMID,receive.ItemId);
            SqlParameter param_recqty = new SqlParameter(PARAM_RECQTY,receive.ReceivedQty);
            SqlParameter param_recdate = new SqlParameter(PARAM_RECDATE,receive.ReceiveDate);
            SqlParameter param_recby = new SqlParameter(PARAM_RECBY,receive.ReceivedBy);
          

            return new SqlParameter[] {param_recid,param_itemid,param_recqty,param_recdate,param_recby };
        }
        #endregion
    }
}
