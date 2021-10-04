namespace csharp.Factories
{
    public abstract class GildedRoseFactory
    {
        protected abstract Item Item { get; }

        public abstract Item UpdateQuality();
    }
}
