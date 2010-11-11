using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Model;
using HRMS.DBUtilities;

namespace DataMapper
{
    public class IssueMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_ALL = "SELECT * FROM Issue";
        private const string SQL_SELECT_ISSUE = "SELECT * FROM Issue where IssueId = @issueid";
        private const string SQL_INSERT_ISSUE = "INSERT INTO Issue VALUES(@issueid,@itemid, @qissued, @issuedate, @issuedby, @issuedto)";
        private const string SQL_DELETE_ISSUE = "DELETE FROM Issue WHERE IssueId = @issueid";
        private const string SQL_UPDATE_ISSUE = "UPDATE Issue SET ItemId = @itemid, QuantityIssued = @qissued, IssueDate = @issuedate, IssuedBy = @issuedby, IssuedTo = @issuedto WHERE IssueId = @issueid";
        private const string PARAM_ISSUEID = "@issueid";
        private const string PARAM_ITEMID = "@itemid";
        private const string PARAM_QISSUE = "@qissued";
        private const string PARAM_ISSUEDATE = "@issuedate";
        private const string PARAM_ISSUEDBY = "@issuedby";
        private const string PARAM_ISSUEDTO = "@issuedto";
        #endregion

        #region PRIVATE CONSTRUCTOR
        private IssueMapper()
        {
        }
        #endregion

        #region PUBLIC METHODS
        public IList<IssueInfo> GetAllIssues()
        {
            IList<IssueInfo> issues = new List<IssueInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ALL, null))
            {
                while (rdr.Read())
                {
                    IssueInfo issue = new IssueInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5));

                    issues.Add(issue);
                }
            }
            return issues;
        }
        public IssueInfo GetIssue(string issueid)
        {
            IssueInfo issue = null;
            SqlParameter param_issueid = new SqlParameter(PARAM_ISSUEID, issueid);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_ISSUE, param_issueid))
            {
                while (rdr.Read())
                {
                    issue = new IssueInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5));
                }
            }
            return issue;
        }

        public void DeleteIssue(IssueInfo issue)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_ISSUE, CreateParameters(issue));
        }
        public void AddIssue(IssueInfo issue)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_ISSUE, CreateParameters(issue));
        }
        public void UpdateIssue(IssueInfo issue)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_ISSUE, CreateParameters(issue));
        }
        #endregion

        #region UTILITIES
        private static IssueMapper instance = new IssueMapper();
        public static IssueMapper GetInstance()
        {
            return instance;
        }
        private SqlParameter[] CreateParameters(IssueInfo issue)
        {
            SqlParameter param_issueid = new SqlParameter(PARAM_ISSUEID,issue.IssueId);
            SqlParameter param_itemId = new SqlParameter(PARAM_ITEMID, issue.ItemId);
            SqlParameter param_qissued = new SqlParameter(PARAM_QISSUE, issue.QuantityIssued);
            SqlParameter param_issuedate = new SqlParameter(PARAM_ISSUEDATE, issue.IssueDate);
            SqlParameter param_issuedby = new SqlParameter(PARAM_ISSUEDBY, issue.IssuedBy);
            SqlParameter param_issuedto = new SqlParameter(PARAM_ISSUEDTO, issue.IssuedTo);

            return new SqlParameter[] { param_issueid,param_itemId, param_qissued, param_issuedate, param_issuedby, param_issuedto };
        }
        #endregion

    }
}
