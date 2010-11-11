using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataMapper;
using Model;
using Microsoft.VisualBasic;
//using Inventory;

namespace InventoryUIL.Add_new
{
    public partial class NewItem : Form
    {
        private ItemInfo item;
        public NewItem()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewItem.Text.Trim() != null & txtNewItem.Text.Trim() != String.Empty)
            {
                if (txtQuanty.Text.Trim() != String.Empty & txtQuanty.Text != null)
                {
                    try
                    {
                        int.Parse(txtQuanty.Text.Trim());
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("Please use figures to specify quantity",exx.Message);
                        return;
                    }
                }
                item = new ItemInfo();
                item.Item = txtNewItem.Text.Trim();
                item.InitialQuantity = txtQuanty.Text.Trim();
                item.InitialEntryDate = System.DateTime.Now.ToLongDateString();
                item.EnteredBy = OtherUtilities.Settings.LoggedInUser.UserId;
                item.CurrentStock = item.InitialQuantity;
            }
            try
            {
                ItemMapper.Getinstance().AddItem(item);
                MessageBox.Show(item.Item + " successfully saved");
                this.Close();
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}