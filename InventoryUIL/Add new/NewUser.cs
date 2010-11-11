using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using DataMapper;

namespace InventoryUIL.Add_new
{
    public partial class NewUser : Form
    {
        private IList<UserLevelInfo> userlevels;
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            InitNewUserPage();
        }
        private void InitNewUserPage()
        {
            LoadUserLevelCombo();
        }
        private void LoadUserLevelCombo()
        {
            userlevels = UserLevelMapper.GetInstance().GetAllUserlevels();
            foreach(UserLevelInfo uli in userlevels)
            {
                cboUserlevel.Items.Add(uli);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ValidateFormFields();
            DoSave();
        }

        private void ValidateFormFields()
        {
            if ((txtFirstname.Text.Trim() == null) | (txtFirstname.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a first name");
                return;
            }
            if ((txtSurname.Text.Trim() == null) | (txtSurname.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a surname");
                return;
            }
            if ((txtUsername.Text.Trim() == null) | (txtUsername.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a Username");
                return;
            }
            if (cboUserlevel.SelectedItem == null)
            {
                MessageBox.Show("Please select the user level for this user");
                return;
            }
            if ((txtPwd1.Text.Trim() == null) | (txtPwd1.Text.Trim() == String.Empty) | (txtPwd2.Text.Trim() == null) | (txtPwd2.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Please fill all the password fields!!");
                return;
            }
            if (txtPwd1.Text.Trim() != txtPwd2.Text.Trim())
            {
                MessageBox.Show("The passwords entered do not match,please enter matching passwords");
                return;
            }
            //MessageBox.Show("Nice!!");
        }
        private void DoSave()
        {
            UserInfo user = new UserInfo();
            user.FirstName = txtFirstname.Text.Trim();
            user.Surname = txtSurname.Text.Trim();
            user.UserName = txtUsername.Text.Trim();
            user.PassWord = txtPwd1.Text.Trim();
            user.UserLevel = ((UserLevelInfo)cboUserlevel.SelectedItem).LevelId;
            user.PhoneNo = txtPhoneNo.Text.Trim() != String.Empty ? txtPhoneNo.Text.Trim() : "";
            user.Email = txtEmail.Text.Trim() != String.Empty ? txtEmail.Text.Trim() : "";

            try
            {
                UserMapper.GetInstance().InsertUser(user);
                MessageBox.Show("new user "+user.UserName + " successfully created");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}