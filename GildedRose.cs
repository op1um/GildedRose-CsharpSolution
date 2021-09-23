using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace csharp
{
    public class GildedRose
    {
        public const string AgedBrie = "Aged Brie";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredItem = "Conjured Mana Cake";
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
            foreach (var item in Items)
            {
                ManageRegularItem(item);
                ManageAgedBrie(item);
                ManageBackstagePasses(item);
                ManageSulfuras(item);
                ManageConjured(item);
            }
        }

        private static bool IsRegular(Item item)
        {
            return !(IsAgedBrie(item) || IsBackstagePasses(item) || IsSulfuras(item) || IsConjured(item));
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

        private static bool IsConjured(Item item)
        {
            return item.Name.Equals(ConjuredItem);
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality--;
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality++;
        }

        private static void ManageRegularItem(Item item)
        {
            if (!IsRegular(item)) return;
            DecreaseSellIn(item);
            DecreaseQuality(item);

            if (item.SellIn <= 0)
            {
                DecreaseQuality(item);
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private static void ManageAgedBrie(Item item)
        {
            if (!IsAgedBrie(item)) return;
            DecreaseSellIn(item);
            IncreaseQuality(item);

            if (item.SellIn <= 0)
            {
                IncreaseQuality(item);
            }

            if (item.Quality > MaximumQuality)
            {
                item.Quality = MaximumQuality;
            }
        }

        private static void ManageBackstagePasses(Item item)
        {
            if (!IsBackstagePasses(item)) return;
            DecreaseSellIn(item);
            IncreaseQuality(item);

            if (item.SellIn < BackstagePassesFirstThreshold)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < BackstagePassesSecondThreshold)
            {
                IncreaseQuality(item);
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

        private static void ManageSulfuras(Item item)
        {
            if (IsSulfuras(item))
            {
                DecreaseSellIn(item);
            }
        }

        private static void ManageConjured(Item item)
        {
            if (IsConjured(item))
            {
                DecreaseSellIn(item);
                DecreaseQuality(item);
                DecreaseQuality(item);

                if (item.SellIn <= 0)
                {
                    DecreaseQuality(item);
                    DecreaseQuality(item);
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
