using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Factories
{
    public class BackstagePasses : GildedRoseFactory
    {
        protected override Item Item { get; }
        public BackstagePasses(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            Item.SellIn--;
            Item.Quality++;

            if (Item.SellIn < 10) Item.Quality++;
            if (Item.SellIn < 5) Item.Quality++;
            if (Item.SellIn <= 0) Item.Quality = 0;
            if (Item.Quality > 50) Item.Quality = 50;
            return Item;
        }
    }
}
