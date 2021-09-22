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
            var item = CreateAndUpdateItem("test", 15, 25);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);
        }

        /* Checking if the quality degrades twice as fast once the sellin is past */
        [Test]
        public void RegularItem_PastSellIn_QualityLowerTwice()
        {
            var item = CreateAndUpdateItem("testSellInPast", 0, 25);
            Assert.AreEqual(23, item.Quality);
        }
    }
}