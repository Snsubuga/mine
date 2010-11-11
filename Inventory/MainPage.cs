using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InventoryUIL.Add_new;
using InventoryUIL.Do_edit;
using InventoryUIL.Transactions;
using DataMapper;
using Model;
using CustomCollection;
//using Microsoft.

namespace Inventory
{
    public partial class MainPage : Form
    {

        #region PRIVATE VARIABLES
        private static UserInfo loggedInUser;
        private DataTable itemTable = new DataTable();
        private DataTable userTable = new DataTable();
        private DataTable userlevelTable = new DataTable();
        private DataTable pastreceivedTable = new DataTable();
        private DataTable pastissuedTable = new DataTable();
        private DataTable pastreturnedTable = new DataTable();
        #endregion

        #region PUBLIC METHODS
        public static UserInfo LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
            set
            {
                loggedInUser = value;
            }
        }
        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region GRID LOAD METHODS
        private void PrepareGridForStock()
        {
            IList<ItemInfo> items = ItemMapper.Getinstance().GetAllItems();
            ClearTable(itemTable);
            itemTable.Columns.AddRange(new DataColumn[] { 
            new DataColumn("ItemId"),
            new DataColumn("Item Name"),
            new DataColumn("Initial Quantity"),
            new DataColumn("Initial Entry Date"),
            new DataColumn("Entered By"),
            new DataColumn("Received"),
            new DataColumn("Issued"),
            new DataColumn("Returned"),
            new DataColumn("Current Stock")});

            foreach (ItemInfo item in items)
            {
                DataRow row = itemTable.NewRow();
                row["ItemId"] = item.ItemId;
                row["Item Name"] = item.Item;
                row["Initial Quantity"] = item.InitialQuantity;
                row["Initial Entry Date"] = item.InitialEntryDate;
                row["Entered By"] = UserMapper.GetInstance().GetUserById(item.EnteredBy).UserName;
                row["Received"] = item.Received;
                row["Issued"] = item.Issued;
                row["Returned"] = item.Returned;
                row["Current Stock"] = item.CurrentStock;

                itemTable.Rows.Add(row);
            }
            dataGridView1.DataSource = itemTable;
            dataGridView1.Columns["ItemId"].Visible = false;
        }
        private void PrepareGridForUsers()
        {
            IList<UserInfo> users = UserMapper.GetInstance().GetAllUsers();
            ClearTable(userTable);
            userTable.Columns.AddRange(new DataColumn[] { 
            new DataColumn("UserId"),
            new DataColumn("UserName"),
            new DataColumn("User Level"),
            new DataColumn("First Name"),
            new DataColumn("Surname"),
            new DataColumn("Phone"),
            new DataColumn("Email")});

            foreach (UserInfo user in users)
            {
                DataRow row = userTable.NewRow();
                row["UserId"] = user.UserId;
                row["UserName"] = user.UserName;
                row["User Level"] = UserLevelMapper.GetInstance().GetUserlevel(user.UserLevel).Level;
                row["First Name"] = user.FirstName;
                row["Surname"] = user.Surname;
                row["Phone"] = user.PhoneNo;
                row["Email"] = user.Email;
                userTable.Rows.Add(row);
            }
            dataGridView1.DataSource = userTable;
            dataGridView1.Columns["UserId"].Visible = false;
        }
        private void PrepareGridForPastIssuedItems()
        {
            IList<IssueInfo> allIssued = OrderByDateIssued(IssueMapper.GetInstance().GetAllIssues());
            ClearTable(pastissuedTable);

            pastissuedTable.Columns.AddRange(new DataColumn[] { 
            new DataColumn("IssueId"),
            new DataColumn("Item Name"),
            new DataColumn("Quantity Issued"),
            new DataColumn("Issue Date"),
            new DataColumn("Issued By"),           
            new DataColumn("Issued To")});

            foreach (IssueInfo issue in allIssued)
            {
                DataRow row = pastissuedTable.NewRow();
                row["IssueId"] = issue.IssueId;
                row["Item Name"] = ItemMapper.Getinstance().GetItem(issue.ItemId).Item;
                row["Quantity Issued"] = issue.QuantityIssued;
                row["Issue Date"] = issue.IssueDate;
                row["Issued By"] = UserMapper.GetInstance().GetUserById(issue.IssuedBy).UserName;
                row["Issued To"] = issue.IssuedTo;

                pastissuedTable.Rows.Add(row);
            }
            dataGridView1.DataSource = pastissuedTable;
            dataGridView1.Columns["IssueId"].Visible = false;
        }
        private void PrepareGridForPastReceivedItems()
        {
            IList<ReceiveInfo> allreceived = OrderByDateReceived(ReceiveMapper.GetInstance().GetAllReceived());

            ClearTable(pastreceivedTable);

            pastreceivedTable.Columns.AddRange(new DataColumn[] {
            new DataColumn("ReceiveId"),
            new DataColumn("Item Name"),
            new DataColumn("Received Quantity"),
            new DataColumn("Received Date"),
            new DataColumn("Received By") });

            foreach (ReceiveInfo receive in allreceived)
            {
                DataRow row = pastreceivedTable.NewRow();
                row["ReceiveId"] = receive.ReceiveId;
                row["Item Name"] = ItemMapper.Getinstance().GetItem(receive.ItemId).Item;
                row["Received Quantity"] = receive.ReceivedQty;
                row["Received Date"] = receive.ReceiveDate;
                row["Received By"] = UserMapper.GetInstance().GetUserById(receive.ReceivedBy).UserName;

                pastreceivedTable.Rows.Add(row);
            }
            dataGridView1.DataSource = pastreceivedTable;
            dataGridView1.Columns["ReceiveId"].Visible = false;

        }
        private void PrepareGridForPastReturnedItems()
        {
            IList<ReturnedInfo> allreturned = OrderByDateReturned(ReturnedMapper.GetInstance().GetAllReturns());
            ClearTable(pastreturnedTable);

            pastreturnedTable.Columns.AddRange(new DataColumn[] { 
            new DataColumn("ReturnId"),
            new DataColumn("Item"),
            new DataColumn("Quantity Returned"),
            new DataColumn("Return Date"),
            new DataColumn("Returned By"), 
            new DataColumn("Received By"),
            new DataColumn("Return Reason")});

            foreach (ReturnedInfo returned in allreturned)
            {
                DataRow row = pastreturnedTable.NewRow();
                row["ReturnId"] = returned.ReturnId;
                row["Item"] = ItemMapper.Getinstance().GetItem(returned.ItemId).Item;
                row["Quantity Returned"] = returned.QuantityReturned;
                row["Return Date"] = returned.ReturnDate;
                row["Returned By"] = returned.ReturnedBy;
                row["Received By"] = UserMapper.GetInstance().GetUserById(returned.ReceivedBy);
                row["Return Reason"] = returned.ReturnReason;

                pastreturnedTable.Rows.Add(row);
            }
            dataGridView1.DataSource = pastreturnedTable;
            dataGridView1.Columns["ReturnId"].Visible = false;
        }
        private void ClearTable(DataTable table)
        {
            table.Columns.Clear();
            table.Rows.Clear();
        }
        
        #region OrderDataByDate
        private IList<ReturnedInfo> OrderByDateReturned(IList<ReturnedInfo> returns)
        {
            LookupCollection ordered = new LookupCollection();
            foreach (ReturnedInfo ret in returns)
            {
                ordered.Add(ret.ReturnId, Convert.ToDateTime(ret.ReturnDate));
            }
            IList<ReturnedInfo> orderedList = new List<ReturnedInfo>();
            Object[] o = new Object[ordered.Count];
            ordered.Keys.CopyTo(o, 0);
            Array.Reverse(o);
            foreach (Object oo in o)
            {
                foreach (ReturnedInfo rt in returns)
                {
                    if (rt.ReturnId == (String)oo)
                    {
                        orderedList.Add(rt);
                    }
                }
            }
            return orderedList;
        }
        private IList<ReceiveInfo> OrderByDateReceived(IList<ReceiveInfo> received)
        {
            LookupCollection ordered = new LookupCollection();
            foreach (ReceiveInfo rec in received)
            {
                ordered.Add(rec.ReceiveId, Convert.ToDateTime(rec.ReceiveDate));
            }
            //ordered.Keys.
            IList<ReceiveInfo> orderedList = new List<ReceiveInfo>();
            Object[] o = new Object[ordered.Count];

            ordered.Keys.CopyTo(o, 0);
            Array.Reverse(o);
            foreach (Object oo in o)
            {
                foreach (ReceiveInfo rc in received)
                {
                    if (rc.ReceiveId == (String)oo)
                    {
                        orderedList.Add(rc);
                    }
                }
            }

            return orderedList;
        }
        private IList<IssueInfo> OrderByDateIssued(IList<IssueInfo> issues)
        {
            LookupCollection ordered = new LookupCollection();
            foreach (IssueInfo issue in issues)
            {
                ordered.Add(issue.IssueId, Convert.ToDateTime(issue.IssueDate));
            }
            IList<IssueInfo> orderedList = new List<IssueInfo>();
            Object[] o = new Object[ordered.Count];
            ordered.Keys.CopyTo(o, 0);
            Array.Reverse(o);
            foreach (Object oo in o)
            {
                foreach (IssueInfo iss in issues)
                {
                    if (iss.IssueId == (String)oo)
                    {
                        orderedList.Add(iss);
                    }
                }
            }
            return orderedList;
        }
        #endregion

        #endregion

        #region EVENT HANDLERS

        private void btnDoIssue_Click(object sender, EventArgs e)
        {
            Issue issuefrm = new Issue();
            issuefrm.ShowDialog();
            PrepareGridForStock();
        }

        private void btnDoReceive_Click(object sender, EventArgs e)
        {
            Receive recfrm = new Receive();
            recfrm.ShowDialog();
            PrepareGridForStock();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string type = dataGridView1.Columns[0].Name;
            
            if(type == "ItemId")
            {
                NewItem itemfrm = new NewItem();
                itemfrm.Text = "Edit Item";
               
                itemfrm.ShowDialog();
                PrepareGridForStock();
            }
            if(type == "UserId")
            {
                EditUser editfrm = new EditUser();
                editfrm.User = UserMapper.GetInstance().GetUserById(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                editfrm.ShowDialog();
                PrepareGridForUsers();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Return returnfrm = new Return();
            returnfrm.ShowDialog();
            PrepareGridForStock();
        }

        private void btnPastRecvd_Click(object sender, EventArgs e)
        {
            PrepareGridForPastReceivedItems();
        }
            
        private void btnPastIssues_Click(object sender, EventArgs e)
        {
            PrepareGridForPastIssuedItems();
        }

        private void btnPastRetns_Click(object sender, EventArgs e)
        {
            PrepareGridForPastReturnedItems();
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            PrepareGridForStock();
        }

        private void btnNewItems_Click_1(object sender, EventArgs e)
        {
            NewItem itempage = new NewItem();
            itempage.ShowDialog();
            PrepareGridForStock();
        }

        private void btnCurrentEmployees_Click_1(object sender, EventArgs e)
        {
            PrepareGridForUsers();
        }

        private void btnNewUsers_Click_1(object sender, EventArgs e)
        {
            NewUser newUserfrm = new NewUser();
            newUserfrm.ShowDialog();
            PrepareGridForUsers();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}