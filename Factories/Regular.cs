namespace csharp.Factories
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
