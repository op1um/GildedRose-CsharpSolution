using System.Collections.Generic;
using csharp.Factories;
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
        readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            GildedRoseFactory factory;
            foreach (var item in Items)
            {
                if(IsRegular(item))
                {
                    factory = new Regular(item);
                    factory.UpdateQuality();
                }
                if (IsAgedBrie(item))
                {
                    factory = new AgedBrie(item);
                    factory.UpdateQuality();
                }
                if (IsBackstagePasses(item))
                {
                    factory = new BackstagePasses(item);
                    factory.UpdateQuality();
                }
                if (IsConjured(item))
                {
                    factory = new Conjured(item);
                    factory.UpdateQuality();
                }
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
    }
}
