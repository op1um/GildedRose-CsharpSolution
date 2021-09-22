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
                if (Items[i].Name != AgedBrie && Items[i].Name != BackstagePasses)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != Sulfuras)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BackstagePasses)
                        {
                            if (Items[i].SellIn < BackstagePassesFirstThreshold)
                            {
                                if (Items[i].Quality < MaximumQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < BackstagePassesSecondThreshold)
                            {
                                if (Items[i].Quality < MaximumQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != Sulfuras)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AgedBrie)
                    {
                        if (Items[i].Name != BackstagePasses)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != Sulfuras)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MaximumQuality)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
