using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Model;
using HRMS.DBUtilities;

namespace DataMapper
{
    public class UserLevelMapper
    {
        #region PRIVATE CONSTANT VARIABLES
        private const string SQL_SELECT_LEVELS = "SELECT * FROM UserLevels";
        private const string SQL_SELECT_LEVEL = "SELECT * FROM UserLevels WHERE Levelid = @levelid";
        private const string SQL_DELETE_LEVEL = "DELETE FROM UserLevels WHERE Levelid = @levelid";
        private const string SQL_INSERT_LEVEL = "INSERT INTO Userlevels VALUES(@levelid, @level)";
        private const string SQL_UPDATE_LEVEL = "UPDATE UserLevels SET Level = @level WHERE Levelid = @levelid";
        private const string PARAM_LEVELID = "@levelid";
        private const string PARAM_LEVEL = "@level";
        #endregion

        #region PUBLIC METHODS

        public IList<UserLevelInfo> GetAllUserlevels()
        {
            IList<UserLevelInfo> userLevels = new List<UserLevelInfo>();

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_LEVELS, null))
            {
                while (rdr.Read())
                {
                    UserLevelInfo userlevel = new UserLevelInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1));

                    userLevels.Add(userlevel);
                }
            }
            return userLevels;
        }
        public UserLevelInfo GetUserlevel(string levelid)
        {
            UserLevelInfo userlevel = null;
            SqlParameter param_levelid = new SqlParameter(PARAM_LEVELID,levelid);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction,
                System.Data.CommandType.Text, SQL_SELECT_LEVEL, param_levelid))
            {
                while (rdr.Read())
                {
                    userlevel = new UserLevelInfo(rdr.GetString(0),
                        rdr.GetValue(1).GetType().Equals(typeof(DBNull)) ? "" : rdr.GetString(1));
                }
            }
            
                return userlevel;
        }
        public void DeleteLevel(UserLevelInfo level)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_DELETE_LEVEL, CreateParameters(level));
        }
        public void UpdateLevel(UserLevelInfo level)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_UPDATE_LEVEL, CreateParameters(level));
        }
        public void InsertLevel(UserLevelInfo level)
        {
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, System.Data.CommandType.Text,
                SQL_INSERT_LEVEL, CreateParameters(level));
        }

        #endregion

        private UserLevelMapper() { }

        private static UserLevelMapper instance = new UserLevelMapper();

        public static UserLevelMapper GetInstance()
        {
            return instance;
        }

        public SqlParameter[] CreateParameters(UserLevelInfo uli)
        {
            SqlParameter param_levelid = new SqlParameter(PARAM_LEVELID,uli.LevelId);
            SqlParameter param_level = new SqlParameter(PARAM_LEVEL,uli.Level);

            return new SqlParameter[] {param_levelid,param_level };
        }
    }
}
