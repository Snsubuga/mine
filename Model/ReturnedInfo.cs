using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReturnedInfo
    {
        #region PRIVATE VARIABLES
        private string returnId;
        private string itemId;
        private string quantityReturned;       
        private string returnDate;
        private string returnedBy;
        private string receivedBy;
        private string returnReason;
        #endregion

        #region PUBLIC CONSTRUCTORS
        public ReturnedInfo()
        {
            returnId = Guid.NewGuid().ToString();
        }
        public ReturnedInfo(string returnid,string itemid,string qtyret ,string returndate,string returnedby,string receivedby,string returnreason)
        {
            returnId = returnid;
            itemId = itemid;
            quantityReturned = qtyret;
            returnDate = returndate;
            returnedBy = returnedby;
            receivedBy = receivedby;
            returnReason = returnreason;
        }
        #endregion

        #region PUBLIC PROPERTIES
        public string ReturnId
        {
            get { return returnId; }

        }
        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public string QuantityReturned
        {
            get { return quantityReturned; }
            set { quantityReturned = value; }
        }
        public string ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }
        public string ReturnedBy
        {
            get { return returnedBy; }
            set { returnedBy = value; }
        }  
        public string ReceivedBy
        {
            get { return receivedBy; }
            set { receivedBy = value; }
        }
        public string ReturnReason
        {
            get { return returnReason; }
            set { returnReason = value; }
        }
        #endregion
    }
}
