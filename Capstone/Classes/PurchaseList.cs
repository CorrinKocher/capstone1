using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseList : IEnumerable<PurchasedItems>
    {

        private List<PurchasedItems> purchasedItemsList = new List<PurchasedItems>();



        public void addToList(PurchasedItems item)
        {
            this.purchasedItemsList.Add(item);
        }

        public IEnumerator<PurchasedItems> GetEnumerator()
        {
            return ((IEnumerable<PurchasedItems>)purchasedItemsList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<PurchasedItems>)purchasedItemsList).GetEnumerator();
        }
    }
}
