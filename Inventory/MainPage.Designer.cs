namespace Inventory
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNewUsers = new System.Windows.Forms.Button();
            this.btnCurrentEmployees = new System.Windows.Forms.Button();
            this.btnNewItems = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPastRetns = new System.Windows.Forms.Button();
            this.btnPastRecvd = new System.Windows.Forms.Button();
            this.btnPastIssues = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDoReceive = new System.Windows.Forms.Button();
            this.btnDoIssue = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(704, 462);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnNewUsers);
            this.groupBox3.Controls.Add(this.btnCurrentEmployees);
            this.groupBox3.Controls.Add(this.btnNewItems);
            this.groupBox3.Controls.Add(this.btnStock);
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 177);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // btnNewUsers
            // 
            this.btnNewUsers.Location = new System.Drawing.Point(7, 111);
            this.btnNewUsers.Name = "btnNewUsers";
            this.btnNewUsers.Size = new System.Drawing.Size(187, 23);
            this.btnNewUsers.TabIndex = 7;
            this.btnNewUsers.Text = "New Users";
            this.btnNewUsers.UseVisualStyleBackColor = true;
            this.btnNewUsers.Click += new System.EventHandler(this.btnNewUsers_Click_1);
            // 
            // btnCurrentEmployees
            // 
            this.btnCurrentEmployees.Location = new System.Drawing.Point(7, 81);
            this.btnCurrentEmployees.Name = "btnCurrentEmployees";
            this.btnCurrentEmployees.Size = new System.Drawing.Size(187, 23);
            this.btnCurrentEmployees.TabIndex = 6;
            this.btnCurrentEmployees.Text = "View Users";
            this.btnCurrentEmployees.UseVisualStyleBackColor = true;
            this.btnCurrentEmployees.Click += new System.EventHandler(this.btnCurrentEmployees_Click_1);
            // 
            // btnNewItems
            // 
            this.btnNewItems.Location = new System.Drawing.Point(7, 51);
            this.btnNewItems.Name = "btnNewItems";
            this.btnNewItems.Size = new System.Drawing.Size(187, 23);
            this.btnNewItems.TabIndex = 5;
            this.btnNewItems.Text = "New Items";
            this.btnNewItems.UseVisualStyleBackColor = true;
            this.btnNewItems.Click += new System.EventHandler(this.btnNewItems_Click_1);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(7, 21);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(187, 23);
            this.btnStock.TabIndex = 4;
            this.btnStock.Text = "Current Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPastRetns);
            this.groupBox2.Controls.Add(this.btnPastRecvd);
            this.groupBox2.Controls.Add(this.btnPastIssues);
            this.groupBox2.Location = new System.Drawing.Point(13, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 105);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Previous";
            // 
            // btnPastRetns
            // 
            this.btnPastRetns.Location = new System.Drawing.Point(7, 78);
            this.btnPastRetns.Name = "btnPastRetns";
            this.btnPastRetns.Size = new System.Drawing.Size(180, 23);
            this.btnPastRetns.TabIndex = 2;
            this.btnPastRetns.Text = "Past Returned";
            this.btnPastRetns.UseVisualStyleBackColor = true;
            this.btnPastRetns.Click += new System.EventHandler(this.btnPastRetns_Click);
            // 
            // btnPastRecvd
            // 
            this.btnPastRecvd.Location = new System.Drawing.Point(7, 49);
            this.btnPastRecvd.Name = "btnPastRecvd";
            this.btnPastRecvd.Size = new System.Drawing.Size(180, 23);
            this.btnPastRecvd.TabIndex = 1;
            this.btnPastRecvd.Text = "Past Received";
            this.btnPastRecvd.UseVisualStyleBackColor = true;
            this.btnPastRecvd.Click += new System.EventHandler(this.btnPastRecvd_Click);
            // 
            // btnPastIssues
            // 
            this.btnPastIssues.Location = new System.Drawing.Point(7, 20);
            this.btnPastIssues.Name = "btnPastIssues";
            this.btnPastIssues.Size = new System.Drawing.Size(180, 23);
            this.btnPastIssues.TabIndex = 0;
            this.btnPastIssues.Text = "Past Issues";
            this.btnPastIssues.UseVisualStyleBackColor = true;
            this.btnPastIssues.Click += new System.EventHandler(this.btnPastIssues_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnDoReceive);
            this.groupBox1.Controls.Add(this.btnDoIssue);
            this.groupBox1.Location = new System.Drawing.Point(13, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transactions";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(7, 80);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(187, 23);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Return Items";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDoReceive
            // 
            this.btnDoReceive.Location = new System.Drawing.Point(7, 50);
            this.btnDoReceive.Name = "btnDoReceive";
            this.btnDoReceive.Size = new System.Drawing.Size(187, 23);
            this.btnDoReceive.TabIndex = 1;
            this.btnDoReceive.Text = "Receive Items";
            this.btnDoReceive.UseVisualStyleBackColor = true;
            this.btnDoReceive.Click += new System.EventHandler(this.btnDoReceive_Click);
            // 
            // btnDoIssue
            // 
            this.btnDoIssue.Location = new System.Drawing.Point(7, 20);
            this.btnDoIssue.Name = "btnDoIssue";
            this.btnDoIssue.Size = new System.Drawing.Size(187, 23);
            this.btnDoIssue.TabIndex = 0;
            this.btnDoIssue.Text = "Issue Items";
            this.btnDoIssue.UseVisualStyleBackColor = true;
            this.btnDoIssue.Click += new System.EventHandler(this.btnDoIssue_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(466, 462);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(7, 141);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit System";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 462);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDoReceive;
        private System.Windows.Forms.Button btnDoIssue;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPastRetns;
        private System.Windows.Forms.Button btnPastRecvd;
        private System.Windows.Forms.Button btnPastIssues;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNewUsers;
        private System.Windows.Forms.Button btnCurrentEmployees;
        private System.Windows.Forms.Button btnNewItems;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnExit;
    }
}