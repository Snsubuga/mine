using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace OtherUtilities
{
    public class Settings
    {
        private static UserInfo user;
        public static UserInfo LoggedInUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
    }
}
