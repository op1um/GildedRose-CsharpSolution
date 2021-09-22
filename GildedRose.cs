using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace csharp
{
    public class GildedRose
    {
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const int MaximumQuality = 50;
        public const int BackstagePassesFirstThreshold = 11;
        public const int BackstagePassesSecondThreshold = 6;
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];

                if (isRegular(item))
                {
                    item.SellIn--;
                    item.Quality--;

                    if (item.SellIn <= 0)
                    {
                        item.Quality--;
                    }

                    if (item.Quality < 0)
                    {
                        item.Quality = 0;
                    }
                }
                else if (IsAgedBrie(item))
                {
                    item.SellIn--;
                    item.Quality++;

                    if (item.SellIn <= 0)
                    {
                        item.Quality++;
                    }

                    if (item.Quality > MaximumQuality)
                    {
                        item.Quality = MaximumQuality;
                    }
                }
                else if (IsBackstagePasses(item))
                {
                    item.SellIn--;
                    item.Quality++;

                    if (item.SellIn < BackstagePassesFirstThreshold)
                    {
                        item.Quality++;
                    }

                    if (item.SellIn < BackstagePassesSecondThreshold)
                    {
                        item.Quality++;
                    }

                    if (item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }

                    if (item.Quality > MaximumQuality)
                    {
                        item.Quality = MaximumQuality;
                    }
                }
                else if (IsSulfuras(item))
                {
                    item.SellIn--;
                }
            }
        }

        private static bool isRegular(Item item)
        {
            return !(IsAgedBrie(item) || IsBackstagePasses(item) || IsSulfuras(item));
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name.Equals(AgedBrie);
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name.Equals(Sulfuras);
        }

        private static bool IsBackstagePasses(Item item)
        {
            return item.Name.Equals(BackstagePasses);
        }
    }
}
