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
    public partial class Receive : Form
    {
        #region PRIVATE VARIABLES
        private IList<ItemInfo> items;
        private IList<UserInfo> users;
        
        #endregion
        public Receive()
        {
            InitializeComponent();
        }

        private void Receive_Load(object sender, EventArgs e)
        {
            InitPage();
        }
        private void InitPage()
        {
            LoadUserCombo();
            LoadItemCombo();
        }
        private void LoadUserCombo()
        {
            users = UserMapper.GetInstance().GetAllUsers();
            foreach (UserInfo user in users)
            {
                cboIssuedBy.Items.Add(user);
            }
            
        }
        private void LoadItemCombo()
        {
            items = ItemMapper.Getinstance().GetAllItems();
            foreach (ItemInfo item in items)
            {
                cboItems.Items.Add(item);
            }
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            ReceiveInfo receive = new ReceiveInfo();
            receive.ItemId = ((ItemInfo)cboItems.SelectedItem).ItemId;
            receive.ReceivedQty = txtQty.Text.Trim();
            receive.ReceivedBy = ((UserInfo)cboIssuedBy.SelectedItem).UserId;
            receive.ReceiveDate = dtpIssue.Text;
            try
            {
                ReceiveMapper.GetInstance().AddReceive(receive);

                ItemInfo item = (ItemInfo)cboItems.SelectedItem;
                item.Received = (Convert.ToInt32(item.Received) + Convert.ToInt32(receive.ReceivedQty)).ToString();
                
                item.CurrentStock = (Convert.ToInt32(item.CurrentStock) + Convert.ToInt32(receive.ReceivedQty)).ToString();
                
                ItemMapper.Getinstance().UpdateItem(item);
                MessageBox.Show("Transaction successful");
                this.Close();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}