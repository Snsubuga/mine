using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataMapper;
using Model;

namespace InventoryUIL.Do_edit
{
    public partial class EditUser : Form
    {
        private UserInfo user;
        private IList<UserLevelInfo> userlevels;
        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            if(user != null)
            {
                txtFirstname.Text = user.FirstName;
                txtSurname.Text = user.Surname;
                txtUsername.Text = user.UserName;
                txtPwd1.Text = user.PassWord;
                txtPhoneNo.Text = user.PhoneNo;
                txtEmail.Text = user.Email;
                LoadUserLevelCombo();
                cboUserlevel.SelectedItem = UserLevelMapper.GetInstance().GetUserlevel(user.UserLevel);
            }

        }
        private void LoadUserLevelCombo()
        {
            userlevels = UserLevelMapper.GetInstance().GetAllUserlevels();
            foreach(UserLevelInfo uli in userlevels)
            {
                cboUserlevel.Items.Add(uli);
            }
        }

        private void btnPwdchange_Click(object sender, EventArgs e)
        {
            if (btnPwdchange.Text == "Change Password")
            {
                btnPwdchange.Text = "Cancel password change";
                label2.Visible = true;
                label2.Text = "Old Password";
                label8.Visible = true;
                txtPwd1.Visible = true;
                txtPwd1.Text = String.Empty;
                txtPwd2.Visible = true;
                label11.Visible = true;
                txtConfirm.Visible = true;
            }
            else
            {
                btnPwdchange.Text = "Change Password";
                label2.Visible = false;
                label8.Visible = false;
                txtPwd1.Text = user.PassWord;
                txtPwd1.Visible = false;
                txtPwd2.Visible = false;
                label11.Visible = false;
                txtConfirm.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateuserChanges())
            {
                DouserUpdate();
            }
            
        }
        private bool ValidateuserChanges()
        {
            if ((txtFirstname.Text.Trim() == null) | (txtFirstname.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a first name");
                return false;
            }
            user.FirstName = txtFirstname.Text.Trim();
            if ((txtSurname.Text.Trim() == null) | (txtSurname.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a surname");
                return false;
            }
            user.Surname = txtSurname.Text.Trim();
            if ((txtUsername.Text.Trim() == null) | (txtUsername.Text.Trim() == String.Empty))
            {
                MessageBox.Show("Please enter a Username");
                return false;
            }
            user.UserName = txtUsername.Text.Trim();
            if (cboUserlevel.SelectedItem == null)
            {
                MessageBox.Show("Please select the user level for this user");
                return false;
            }
            user.UserLevel = ((UserLevelInfo)cboUserlevel.SelectedItem).LevelId;
            if (btnPwdchange.Text == "Cancel password change" & txtPwd1.Visible == true)
            {
                if (txtPwd1.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Enter the old password");
                    return false;
                }
                if (txtPwd2.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Enter the new password");
                    return false;
                }
                if (txtConfirm.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Confirm new password!!");
                    return false;
                }
                if (txtPwd2.Text.Trim() != txtConfirm.Text.Trim())
                {
                    MessageBox.Show("The 2 new passwords do not match");
                    return false;
                }
                
                user.PassWord = txtConfirm.Text;
                return true;
            }
            return true;
            
        }
        private void DouserUpdate()
        {
            try
            {
                UserMapper.GetInstance().UpdateUser(user);
                MessageBox.Show("Changes successfully saved!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}