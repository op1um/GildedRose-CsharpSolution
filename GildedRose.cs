using System.Collections.Generic;

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

                if (item.Name != AgedBrie && item.Name != BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePasses)
                        {
                            if (item.SellIn < BackstagePassesFirstThreshold)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < BackstagePassesSecondThreshold)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != Sulfuras)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrie)
                    {
                        if (item.Name != BackstagePasses)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != Sulfuras)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaximumQuality)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
