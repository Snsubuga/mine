using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserLevelInfo
    {
        private string levelid;
        private string level;

        #region Constructors
        public UserLevelInfo()
        {
            levelid = Guid.NewGuid().ToString();
        }
        public UserLevelInfo(string levelid, string level)
        {
            this.levelid = levelid;
            this.level = level;
        }
        #endregion

        #region Public Properties

        public string LevelId
        {
            get
            {
                return levelid;
            }
        }
        public string Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj != null & obj.GetType() == typeof(UserLevelInfo))
            {
                return this.Level.Equals(((UserLevelInfo)obj).Level);
            }
            else
            {
                return base.Equals(obj);
            }
        }
        public override int GetHashCode()
        {
            return this.Level.Length;
        }

        public override string ToString()
        {
            return this.Level;
        }
        #endregion
    }
}
