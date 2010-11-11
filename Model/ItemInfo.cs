using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ItemInfo
    {
        #region Private variables
        private string itemid;
        private string itemName;
        private string initQuantity;
        private string initEntryDate;
        private string enteredBy;
        private string received;

       
        private string issued;

        
        private string returned;

        
        private string currentStock;
       
        #endregion

        #region Constructors
        public ItemInfo()
        {
            itemid = Guid.NewGuid().ToString();
        }

        public ItemInfo(string id, string name, string q,string date,string enteredby,string rcvd, string issued,string returned,string cs)
        {
            itemid = id;
            itemName = name;
            initQuantity = q;
            initEntryDate = date;
            enteredBy = enteredby;
            received = rcvd;
            this.issued = issued;
            this.returned = returned;
            currentStock = cs;

        }

        #endregion

        #region Public properties
        public string ItemId
        {
            get
            {
                return itemid;
            }
            set
            {
                itemid = value;
            }
        }
        public string Item
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }
        public string InitialQuantity
        {
            get
            {
                return initQuantity;
            }
            set
            {
                initQuantity = value;
            }
        }
        public string InitialEntryDate
        {
            get
            {
                return initEntryDate;
            }
            set
            {
                initEntryDate = value;
            }
            
        }
        public string EnteredBy
        {
            get
            {
                return enteredBy;
            }
            set
            {
                enteredBy = value;
            }
        }
        public string Received
        {
            get { return received; }
            set { received = value; }
        }
        public string Issued
        {
            get { return issued; }
            set { issued = value; }
        }
        public string Returned
        {
            get { return returned; }
            set { returned = value; }
        }
        public string CurrentStock
        {
            get { return currentStock; }
            set { currentStock = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            return this.itemName;
        }
        public override bool Equals(object obj)
        {
            if (obj != null & obj.GetType() == typeof(ItemInfo))
            {
                return this.itemName.Equals(((ItemInfo)obj).itemName);
            }
            else
            {
                return base.Equals(obj);
            }
        }
        public override int GetHashCode()
        {
            return this.itemName.Length;
        }
        #endregion
    }
    
}
