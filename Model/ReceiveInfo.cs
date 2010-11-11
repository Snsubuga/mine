using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReceiveInfo
    {
        #region PRIVATE VARIABLES
        private string receiveId;
        private string itemId;
        private string receivedQty;
        private string receiveDate;
        private string receivedBy;

        #endregion

        #region PUBLIC CONSTRUCTORS
        public ReceiveInfo()
        {
            receiveId = Guid.NewGuid().ToString();
        }
        public ReceiveInfo(string recid,string itemid,string recqty,string recdate,string recby)
        {
            receiveId = recid;
            itemId = itemid;
            receivedQty = recqty;
            receiveDate = recdate;
            receivedBy = recby;
        }
        #endregion

        #region PUBLIC PROPERTIES

        public string ReceiveId
        {
            get { return receiveId; }
            set { receiveId = value; }
        }

        public string ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public string ReceivedQty
        {
            get { return receivedQty; }
            set { receivedQty = value; }
        }
        public string ReceiveDate
        {
            get { return receiveDate; }
            set { receiveDate = value; }
        }

        public string ReceivedBy
        {
            get { return receivedBy; }
            set { receivedBy = value; }
        }
        #endregion
    }
}
