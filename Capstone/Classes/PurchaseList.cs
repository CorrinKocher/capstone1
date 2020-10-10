using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseList : IEnumerable<PurchasedItems>
    {
        //set up a list to hold purchased items
        private List<PurchasedItems> purchasedItemsList = new List<PurchasedItems>();


        //adds thngs to the purchasedItemsList
        public void addToList(PurchasedItems item)
        {
            this.purchasedItemsList.Add(item);
        }
        //some of Matt's witchcraft for lists
        public IEnumerator<PurchasedItems> GetEnumerator()
        {
            return ((IEnumerable<PurchasedItems>)purchasedItemsList).GetEnumerator();
        }

        //some of Matt's witchcraft for lists
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<PurchasedItems>)purchasedItemsList).GetEnumerator();
        }
    }
}
