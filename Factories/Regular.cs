using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class Regular : GildedRoseFactory
    {
        protected override Item Item { get; }
        public Regular(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            Item.SellIn--;
            Item.Quality--;

            if (Item.SellIn <= 0) Item.Quality--;
            if (Item.Quality < 0) Item.Quality = 0;
            return Item;
        }
    }
}
