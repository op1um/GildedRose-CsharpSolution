using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class ApprovalTests
    {

        // item creation method to respect the DRY principle
        private Item CreateAndUpdateItem(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> { new Item
                {
                    Name = name, SellIn = sellIn, Quality = quality
                }
            };
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            return items[0];
        }

        //First test to check if the unit testing framework is running fine
        [Test]
        public void BasicTest()
        {
            Assert.True(true);
        }

        /* Since we can't know what the app does, even if the business says the app
        already does everything they want. We need unit tests to check if this is true and to make sure
        we don't make any regression during the refactoring */
        [Test]
        public void RegularItem_SellInAndQualityLower()
        {
            var item = CreateAndUpdateItem("regularItem", 15, 25);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);
        }

        /* Checking if the quality degrades twice as fast once the sellIn is past */
        [Test]
        public void RegularItem_PastSellIn_QualityLowerTwice()
        {
            var item = CreateAndUpdateItem("regularItem", 0, 25);
            Assert.AreEqual(23, item.Quality);
        }

        /* Checking if the quality of an item can't be negative */
        [Test]
        public void RegularItem_QualityCantBeNegative()
        {
            var item = CreateAndUpdateItem("regularItem", 3, 0);
            Assert.AreEqual(0, item.Quality);
        }

        /* Checking if the quality of the Aged Brie increases with time */
        [Test]
        public void AgedBrie_QualityIncrease()
        {
            var item = CreateAndUpdateItem("Aged Brie", 15, 10);
            Assert.AreEqual(11, item.Quality);
        }

        /* Checking if the quality can't be more than 50 */
        [Test]
        public void AgedBrie_QualityCantBeMoreThan50()
        {
            var item = CreateAndUpdateItem("Aged Brie", 10, 50);
            Assert.AreEqual(50, item.Quality);
        }

        /* Checking if Sulfuras quality never decrease */
        [Test]
        public void Sulfuras_QualityNeverDecrease()
        {
            var item = CreateAndUpdateItem("Sulfuras, Hand of Ragnaros", 10, 80);
            Assert.AreEqual(80, item.Quality);
        }

        /* Checking if Backstage passes quality increases */
        [Test]
        public void BackstagePasses_QualityIncrease()
        {
            var item = CreateAndUpdateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            Assert.AreEqual(21, item.Quality);
        }
    }
}