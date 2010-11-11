using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataMapper;
using Model;
using OtherUtilities;

namespace Inventory
{
    public partial class Login : Form
    {
        private IList<UserInfo> users;
        private string username;
        private string password;
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (ValidateMe())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong User Credentials","User Login Failed!");
                return;
            }
        }

        private bool ValidateMe()
        {
            if (txtUsername.Text.Trim() != null & txtUsername.Text.Trim() != String.Empty)
            {
                username = txtUsername.Text.Trim();
            }
            else
            {
                MessageBox.Show("username cannot be empty or null");
                return false;
            }
            if (txtPwd.Text.Trim() != null & txtPwd.Text.Trim() != String.Empty)
            {
                password = txtPwd.Text.Trim();
            }
            UserInfo user = UserMapper.GetInstance().GetUserByUserName(username);
            if (user != null & user.PassWord == txtPwd.Text.Trim())
            {

                Settings.LoggedInUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            users = UserMapper.GetInstance().GetAllUsers();
        }
    }
}