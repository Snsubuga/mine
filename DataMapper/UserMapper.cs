using System;
using System.Collections.Generic;
using System.Text;
using HRMS.DBUtilities;
using Model;
using System.Data.SqlClient;

namespace DataMapper
{
    public class UserMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_USERS = "SELECT * FROM Users ORDER BY UserName ASC";
        private const string SQL_SELECT_USER_BY_ID = "SELECT * FROM Users WHERE Userid = @userid";
        private const string SQL_SELECT_USER_BY_NAME = "SELECT * FROM Users WHERE UserName = @username";
        private const string SQL_DELETE_USER = "DELETE FROM Users WHERE Userid = @userid";
        private const string SQL_UPDATE_USER = "UPDATE Users SET UserName = @username,PassWord = @password, UserLevel = @userlevel, FirstName = @fname, Surname = @sname, PhoneNumber = @phone, Email = @email WHERE Userid = @userid";
        private const string SQL_INSERT_USER = "INSERT INTO Users VALUES(@userid,@username, @password,@userlevel,@fname,@sname,@phone,@email)";
        private const string PARAM_USERID = "@userid";
        private const string PARAM_USERNAME = "@username";
        private const string PARAM_PWD = "@password";
        private const string PARAM_USERLVL = "@userlevel";
        private const string PARAM_FNAME = "@fname";
        private const string PARAM_SNAME = "@sname";
        private const string PARAM_PHONE = "@phone";
        private const string PARAM_EMAIL = "@email";
        #endregion

        #region PUBLIC METHODS
        public IList<UserInfo> GetAllUsers()
        {
            IList<UserInfo> allUsers = new List<UserInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_USERS, null))
            {
                while (rdr.Read())
                {
                    UserInfo user = new UserInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6),
                        rdr.GetValue(7).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(7));

                    allUsers.Add(user);
                }
            }
            return allUsers;
        }
        public UserInfo GetUserById(string id)
        {
            UserInfo user = null;
            SqlParameter param_userid = new SqlParameter(PARAM_USERID,id);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_USER_BY_ID, param_userid))
            {
                while (rdr.Read())
                {
                    user = new UserInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6),
                        rdr.GetValue(7).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(7));
                }
            }
            return user;
        }
        public UserInfo GetUserByUserName(string username)
        {
            UserInfo user = null;
            SqlParameter param_username = new SqlParameter(PARAM_USERNAME, username);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_USER_BY_NAME, param_username))
            {
                while (rdr.Read())
                {
                    user = new UserInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1),
                        rdr.GetValue(2).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(2),
                        rdr.GetValue(3).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(3),
                        rdr.GetValue(4).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(4),
                        rdr.GetValue(5).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(5),
                        rdr.GetValue(6).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(6),
                        rdr.GetValue(7).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(7));
                }
            }
            return user;
        }
        public void DeleteUser(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_USER, CreateParameters(user));
        }
        public void InsertUser(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_USER, CreateParameters(user));
        }
        public void UpdateUser(UserInfo user)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_USER, CreateParameters(user));
        }
        #endregion

        private UserMapper() { }
        private static UserMapper instance = new UserMapper();
        public static UserMapper GetInstance()
        {
            return instance;
        }
        public SqlParameter[] CreateParameters(UserInfo user)
        {
            SqlParameter param_userid = new SqlParameter(PARAM_USERID,user.UserId);
            SqlParameter param_username = new SqlParameter(PARAM_USERNAME,user.UserName);
            SqlParameter param_passwd = new SqlParameter(PARAM_PWD,user.PassWord);
            SqlParameter param_level = new SqlParameter(PARAM_USERLVL,user.UserLevel);
            SqlParameter param_fname = new SqlParameter(PARAM_FNAME, user.FirstName);
            SqlParameter param_sname = new SqlParameter(PARAM_SNAME, user.Surname);
            SqlParameter param_phone = new SqlParameter(PARAM_PHONE,user.PhoneNo);
            SqlParameter param_email = new SqlParameter(PARAM_EMAIL, user.Email);

            return new SqlParameter[] {param_userid,param_username,param_passwd,param_level,param_fname,param_sname,param_phone,param_email };
        }
    }
}
