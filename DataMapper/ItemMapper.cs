using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using HRMS.DBUtilities;

namespace DataMapper
{
    public class ItemMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_ALL = "SELECT * FROM Item ORDER BY ItemName ASC";
        private const string SQL_SELECT_ITEM = "SELECT * FROM Item where ItemId = @itemid";
        private const string SQL_INSERT_ITEM = "INSERT INTO Item VALUES(@itemid, @itemName, @initq, @initdate, @enterer, @received, @issued, @returned, @currentstock)";
        private const string SQL_DELETE_ITEM = "DELETE FROM Item WHERE ItemId = @itemid";
        private const string SQL_UPDATE_ITEM = "UPDATE Item SET ItemName = @itemName, InitialQuantity = @initq, InitialEntryDate = @initdate, Enterer = @enterer, Received = @received, Issued = @issued, Returned = @returned,CurrentStock = @currentstock WHERE ItemId = @itemid";
        private const string PARAM_ITEMID = "@itemid";
        private const string PARAM_ITEM = "@itemName";
        private const string PARAM_INITQ = "@initq";
        private const string PARAM_INITDATE = "@initdate";
        private const string PARAM_ENTEREDBY = "@enterer";
        private const string PARAM_RCVD = "@received";
        private const string PARAM_ISSUED = "@issued";
        private const string PARAM_RETURNED = "@returned";
        private const string PARAM_CURRSTOCK = "@currentstock";
        #endregion

        #region PRIVATE CONSTRUCTOR
        private ItemMapper()
        {
        }
        #endregion
             
        #region PUBLIC METHODS
        public IList<ItemInfo> GetAllItems()
        {
            IList<ItemInfo> items = new List<ItemInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ALL, null))
            {
                while (rdr.Read())
                {
                    ItemInfo item = new ItemInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" :rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6),
                        rdr.GetValue(7).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(7),
                        rdr.GetValue(8).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(8));

                    items.Add(item);
                }
            }
            return items;
        }
        public ItemInfo GetItem(string itemid)
        {
            ItemInfo item = null;
            SqlParameter param_itemid = new SqlParameter(PARAM_ITEMID,itemid);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ITEM, param_itemid))
            {
                while (rdr.Read())
                {
                    item = new ItemInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" :rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6),
                        rdr.GetValue(7).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(7),
                        rdr.GetValue(8).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(8));
                }
            }
            return item;
        }

        public void DeleteItem(ItemInfo item)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_ITEM, CreateParameters(item));
        }
        public void AddItem(ItemInfo item)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_ITEM, CreateParameters(item));
        }
        public void UpdateItem(ItemInfo item)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_ITEM, CreateParameters(item));
        }
        #endregion

        #region UTILITIES
        private static ItemMapper instance = new ItemMapper();
        public static ItemMapper Getinstance()
        {
            return instance;
        }
        public SqlParameter[] CreateParameters(ItemInfo item)
        {
            SqlParameter param_itemId = new SqlParameter(PARAM_ITEMID, item.ItemId);
            SqlParameter param_item = new SqlParameter(PARAM_ITEM, item.Item);
            SqlParameter param_initq = new SqlParameter(PARAM_INITQ, item.InitialQuantity);
            SqlParameter param_initdate = new SqlParameter(PARAM_INITDATE, item.InitialEntryDate);
            SqlParameter param_enterer = new SqlParameter(PARAM_ENTEREDBY, item.EnteredBy);
            SqlParameter param_rcvd = new SqlParameter(PARAM_RCVD,item.Received);
            SqlParameter param_issued = new SqlParameter(PARAM_ISSUED,item.Issued);
            SqlParameter param_returned = new SqlParameter(PARAM_RETURNED,item.Returned);
            SqlParameter param_currstock = new SqlParameter(PARAM_CURRSTOCK, item.CurrentStock);

            return new SqlParameter[] { param_itemId, param_item, param_initq, param_initdate, param_enterer, param_rcvd, param_issued, param_returned, param_currstock };
        }
        #endregion
    }
}
