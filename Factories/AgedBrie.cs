namespace csharp.Factories
{
    public class AgedBrie : GildedRoseFactory
    {
        protected override Item Item { get; }
        public AgedBrie(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            Item.SellIn--;
            Item.Quality++;

            if (Item.SellIn <= 0) Item.Quality++;
            if (Item.Quality > 50) Item.Quality = 50;
            return Item;
        }
    }
}
