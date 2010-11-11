using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class IssueInfo
    {
        #region PRIVATE VARIABLES
        private string issueId;
        private string itemId;
        private string quantityIssued;
        private string issueDate;
        private string issuedBy;
        private string issuedTo;
               
        #endregion

        #region PUBLIC CONSTRUCTORS
        public IssueInfo()
        {
            issueId = Guid.NewGuid().ToString();
        }
        public IssueInfo(string issueid,string itemid,string qi,string issuedate,string issuedby,string issuedto)
        {
            issueId = issueid;
            itemId = itemid;
            quantityIssued = qi;
            issueDate = issuedate;
            issuedBy = issuedby;
            issuedTo = issuedto;
        }
        #endregion

        #region PUBLIC PROPERTIES
        public string IssueId
        {
            get { return issueId; }
            set { issueId = value; }
        }
        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public string QuantityIssued
        {
            get { return quantityIssued; }
            set { quantityIssued = value; }
        }
        public string IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }
        public string IssuedBy
        {
            get { return issuedBy; }
            set { issuedBy = value; }
        }
        public string IssuedTo
        {
            get { return issuedTo; }
            set { issuedTo = value; }
        }
        #endregion
    }
}
