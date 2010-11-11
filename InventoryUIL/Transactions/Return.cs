using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;
using DataMapper;

namespace InventoryUIL.Transactions
{
    public partial class Return : Form
    {
        private IList<UserInfo> users;
        private IList<ItemInfo> items;
        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            LoadItemCombobox();
            LoadUserCombobox();
        }
        private void LoadItemCombobox()
        {
            items = ItemMapper.Getinstance().GetAllItems();
            foreach(ItemInfo item in items)
            {
                cboItems.Items.Add(item);
            }
        }
        private void LoadUserCombobox()
        {
            users = UserMapper.GetInstance().GetAllUsers();
            foreach(UserInfo user in users)
            {
                cboUsers.Items.Add(user);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateReturnFormFields())
            {
                DoReturn();
            }
        }
        private bool ValidateReturnFormFields()
        {
            if(cboItems.SelectedItem == null)
            {
                MessageBox.Show("Please select an item");
                return false;
            }
            if(txtQty.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter the number of items to be returned");
                return false;
            }
            if (dtpReturn.Text == null | dtpReturn.Text == String.Empty)
            {
                MessageBox.Show("Please specify the date the items were returned");
                return false;
            }
            if (txtRetBy.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Who returned the item(s)?");
                return false;
            }
            if (cboUsers.SelectedItem == null)
            {
                MessageBox.Show("Who received the items?");
                return false;
            }
            if(Convert.ToInt32(txtQty.Text.Trim()) > (Convert.ToInt32(txtIssued.Text.Trim())))
            {
                MessageBox.Show("Quantity returned cannot exceed quantity originally issued out");
                return false;
            }
            return true;
        }
        private void DoReturn()
        {
            ReturnedInfo returnobj = new ReturnedInfo();
            returnobj.ItemId = ((ItemInfo)cboItems.SelectedItem).ItemId;
            returnobj.QuantityReturned = txtQty.Text.Trim();
            returnobj.ReturnDate = dtpReturn.Text;
            returnobj.ReturnedBy = txtRetBy.Text.Trim();
            returnobj.ReceivedBy = ((UserInfo)cboUsers.SelectedItem).UserId;
            returnobj.ReturnReason = txtReturnReason.Text.Trim();

            try
            {
                ReturnedMapper.GetInstance().InsertReturn(returnobj);

                ItemInfo item = ItemMapper.Getinstance().GetItem(returnobj.ItemId);
                item.Returned = (Convert.ToInt32(item.Returned) + Convert.ToInt32(returnobj.QuantityReturned)).ToString();
                item.CurrentStock = (Convert.ToInt32(item.CurrentStock) + Convert.ToInt32(returnobj.QuantityReturned)).ToString();

                ItemMapper.Getinstance().UpdateItem(item);
                MessageBox.Show("Transaction Successfully completed");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboItems_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtIssued.Text = ((ItemInfo)cboItems.SelectedItem).Issued;
        }
    }
}