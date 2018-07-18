using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateItem()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Quality = QualityUpdater.GetUpdatedQuality(Items[i]);
                Items[i].SellIn = Math.Max(Items[i].SellIn - 1, 0);
            }
        }


    }
}
