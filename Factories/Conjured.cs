using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Factories
{
    public class Conjured : GildedRoseFactory
    {
        protected override Item Item { get; }
        public Conjured(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            Item.SellIn--;
            Item.Quality--;
            Item.Quality--;

            if (Item.SellIn <= 0)
            {
                Item.Quality--;
                Item.Quality--;
            }

            if (Item.Quality < 0) Item.Quality = 0;
            return Item;
        }
    }
}
