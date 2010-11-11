using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataMapper;
using Model;

namespace InventoryUIL.Transactions
{
    public partial class Issue : Form
    {
        private IList<ItemInfo> items;
        private IList<UserInfo> users;
        public Issue()
        {
            InitializeComponent();
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            InitIssuePage();
        }
        private void InitIssuePage()
        {
            LoadItemCombo();
            LoadUserCombo();
        }
        private void LoadItemCombo()
        {
            items = ItemMapper.Getinstance().GetAllItems();
            foreach(ItemInfo item in items)
            {
                cboItems.Items.Add(item);
            }
        }
        private void LoadUserCombo()
        {
            users = UserMapper.GetInstance().GetAllUsers();
            foreach(UserInfo user in users)
            {
                cboUsers.Items.Add(user);
               
            }
        }

        private void cboItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCurrentStk.Text = ((ItemInfo)cboItems.SelectedItem).CurrentStock;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateIssueData())
            {
                DoIssue();
            }
        }
        private bool ValidateIssueData()
        {
            if(cboItems.SelectedItem == null)
            {
                MessageBox.Show("No item selected");
                return false;
            }
            if (txtQty.Text.Trim() == String.Empty)
            {
                MessageBox.Show("No quantity selected");
                return false;
            }
            if (dtpIssue.Text == null)
            {
                MessageBox.Show("Date cannot be empty");
                return false;
            }
            if (cboUsers.SelectedItem == null)
            {
                MessageBox.Show("Who issued these items?");
                return false;
            }
            if(txtIssuedTo.Text.Trim() == String.Empty)
            {
                MessageBox.Show("To whom were the items issued to?");
                return false;
            }
            if(Convert.ToInt32(txtQty.Text.Trim()) > Convert.ToInt32(txtCurrentStk.Text.Trim()))
            {
                MessageBox.Show("You cant give out more than you have!!!");
                return false;
            }
            return true;
        }
        private void DoIssue()
        {
            IssueInfo issue = new IssueInfo();
            issue.ItemId = ((ItemInfo)cboItems.SelectedItem).ItemId;
            issue.QuantityIssued = txtQty.Text.Trim();
            issue.IssueDate = dtpIssue.Text;
            issue.IssuedBy = ((UserInfo)cboUsers.SelectedItem).UserId;
            issue.IssuedTo = txtIssuedTo.Text.Trim();

            try
            {
                IssueMapper.GetInstance().AddIssue(issue);

                ItemInfo item = (ItemInfo)cboItems.SelectedItem;
                item.Issued = (Convert.ToInt32(item.Issued) + Convert.ToInt32(issue.QuantityIssued)).ToString();
                item.CurrentStock = (Convert.ToInt32(item.CurrentStock) - Convert.ToInt32(issue.QuantityIssued)).ToString();

                ItemMapper.Getinstance().UpdateItem(item);
                MessageBox.Show("Transaction completed successfully");
                this.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
    }
}