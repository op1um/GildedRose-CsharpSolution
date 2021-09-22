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

                if (!(IsAgedBrie(item) || IsBackstagePasses(item)))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsSulfuras(item))
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (IsBackstagePasses(item))
                        {
                            if (item.SellIn < BackstagePassesFirstThreshold)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < BackstagePassesSecondThreshold)
                            {
                                if (item.Quality < MaximumQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (!IsSulfuras(item))
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (!IsAgedBrie(item))
                    {
                        if (!IsBackstagePasses(item))
                        {
                            if (item.Quality > 0)
                            {
                                if (!IsSulfuras(item))
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaximumQuality)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
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
