using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class ApprovalTests
    {
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
            IList<Item> items = new List<Item> { new Item
            {
                Name = "test", SellIn = 15, Quality = 25 }

            };
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            Assert.AreEqual(14, items[0].SellIn);
            Assert.AreEqual(24, items[0].Quality);
        }

        /* Checking if the quality degrades twice as fast once the sellin is past */
        [Test]
        public void RegularItem_PastSellIn_QualityLowerTwice()
        {
            IList<Item> items = new List<Item> { new Item
                {
                    Name = "testSellInPast", SellIn = 0, Quality = 25 }

            };
            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            Assert.AreEqual(23, items[0].Quality);
        }
    }
}