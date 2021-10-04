using System;
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
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (item.Name.Equals(Sulfuras)) continue;
                GildedRoseFactory factory;
                switch (item.Name)
                {
                    case AgedBrie:
                        factory = new AgedBrie(item);
                        break;
                    case BackstagePasses:
                        factory = new BackstagePasses(item);
                        break;
                    case ConjuredItem:
                        factory = new Conjured(item);
                        break;
                    default:
                        factory = new Regular(item);
                        break;
                }
                factory.UpdateQuality();
            }
        }
    }
}
