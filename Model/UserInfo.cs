using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   
    public class UserInfo
    {
        #region Private variables
        private string userid;
        private string userName;
        private string password;
        private string userlevel;
        private string firstName;
        private string surname;
        private string phoneNo;
        private string email;
       
        #endregion

        #region Constructors

        public UserInfo()
        {
            userid = Guid.NewGuid().ToString();
        }

        public UserInfo(string uid,string user, string pwd, string level,string fn,string sn,string phone,string email)
        {
            userid = uid;
            userName = user;
            password = pwd;
            userlevel = level;
            firstName = fn;
            surname = sn;
            phoneNo = phone;
            this.email = email;
        }
        #endregion

        #region Public Properties
        public string UserId
        {
            get
            {
                return userid;
            }
        }
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string UserLevel
        {
            get
            {
                return userlevel;
            }
            set
            {
                userlevel = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj != null & obj.GetType() == typeof(UserInfo))
            {
                return this.userlevel.Equals(((UserInfo)obj).userlevel);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return this.userlevel.Length;
        }
        public override string ToString()
        {
            return this.UserName; ;
        }
        #endregion
    }
}
