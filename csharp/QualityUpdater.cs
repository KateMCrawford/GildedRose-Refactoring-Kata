using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    static class QualityUpdater
    {
        public static int GetUpdatedQuality(Item item)
        {
            switch (item.Name)
            {
                case ("Sulfuras, Hand of Ragnaros"):
                    return UpdateLegendaryQuality(item);

                case ("Aged Brie"):
                    return UpdateAgedBrieQuality(item);

                case ("Backstage passes to a TAFKAL80ETC concert"):
                    return UpdateBackstagePassQuality(item);

                default:
                    if (item.Name.StartsWith("Conjured"))
                        return UpdateConjuredQuality(item);
                    else
                        return UpdateGenericQuality(item);
            }
        }

        private static int UpdateBackstagePassQuality(Item item)
        {
            if (item.SellIn == 0)
            {
                return 0;
            }
            else if (item.SellIn > 10)
            {
                return Math.Min(50, item.Quality + 1);
            }
            else if (item.SellIn < 11 && item.SellIn > 5)
            {
                return Math.Min(50, item.Quality + 2);
            }
            else
            {
                return Math.Min(50, item.Quality + 3);
            }

        }

        private static int UpdateLegendaryQuality(Item item)
        {
            return item.Quality;
        }

        private static int UpdateAgedBrieQuality(Item item)
        {
            return Math.Min(50, item.Quality + 1);
        }

        private static int UpdateGenericQuality(Item item)
        {
            if (item.SellIn > 0)
            {
                return Math.Max(0, item.Quality - 1);
            }
            else
            {
                return Math.Max(0, item.Quality - 2);
            }
        }

        private static int UpdateConjuredQuality(Item item)
        {
            if (item.SellIn > 0)
            {
                return Math.Max(0, item.Quality - 2);
            }
            else
            {
                return Math.Max(0, item.Quality - 4);
            }
        }
    }
}
