using System.Collections.Generic;
using csharp;
using NUnit.Framework;

namespace GildedRoseTests
{
    [TestFixture]
    public class ApprovalTests
    {

        /* item creation method to respect the DRY principle */
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

        /* First test to check if the unit testing framework is running fine */
        [Test]
        public void BasicTest()
        {
            Assert.True(true);
        }

        /* Since we can't know what the app does, even if the business says the app
        already does everything they want. We need unit tests to check if this is true and to make sure
        we don't make any regression during the refactoring */

        /* Checking if the quality of an item degrades with time */
        [Test]
        public void RegularItem_SellInAndQualityLower()
        {
            var item = CreateAndUpdateItem("regularItem", 15, 25);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(24, item.Quality);
        }

        /* Checking if the quality degrades twice as fast once the sellIn is passed */
        [Test]
        public void RegularItem_passedSellIn_QualityLowerTwice()
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

        /* Checking if the quality of an item can't be negative even past sellIn */
        [Test]
        public void RegularItem_PassedSellIn_QualityCantBeNegative()
        {
            var item = CreateAndUpdateItem("regularItem", -1, 0);
            Assert.AreEqual(0, item.Quality);
        }

        /* Checking if the quality of the Aged Brie increases with time */
        [Test]
        public void AgedBrie_QualityIncrease()
        {
            var item = CreateAndUpdateItem(GildedRose.AgedBrie, 15, 10);
            Assert.AreEqual(11, item.Quality);
        }

        /* Checking if the quality of the Aged Brie Increase twice once SellIn is passed */
        [Test]
        public void AgedBrie_PassedSellIn_QualityIncreaseTwice()
        {
            var item = CreateAndUpdateItem(GildedRose.AgedBrie, 0, 10);
            Assert.AreEqual(12, item.Quality);
        }

        /* Checking if the quality of Aged Brie can't be more than GildedRose.MaximumQuality */
        [Test]
        public void AgedBrie_QualityCantBeMoreThanMaximumQuality()
        {
            var item = CreateAndUpdateItem(GildedRose.AgedBrie, 10, GildedRose.MaximumQuality);
            Assert.AreEqual(GildedRose.MaximumQuality, item.Quality);
        }

        /* Checking if the quality of the Aged Brie can't be more then GildedRose.MaximumQuality even past SellIn */
        [Test]
        public void AgedBrie_PassedSellIn_QualityCantBeMoreThanMaximumQuality()
        {
            var item = CreateAndUpdateItem(GildedRose.AgedBrie, 0, 49);
            Assert.AreEqual(GildedRose.MaximumQuality, item.Quality);
        }

        /* Checking if Sulfuras quality never decrease */
        [Test]
        public void Sulfuras_QualityNeverDecrease()
        {
            var item = CreateAndUpdateItem(GildedRose.Sulfuras, 10, 80);
            Assert.AreEqual(80, item.Quality);
        }

        /* Checking if Sulfuras quality never decrease even when sellIn is passed */
        [Test]
        public void Sulfuras_PassedSellIn_QualityNeverDecrease()
        {
            var item = CreateAndUpdateItem(GildedRose.Sulfuras, -1, 80);
            Assert.AreEqual(80, item.Quality);
        }

        /* Checking if Backstage passes quality increases */
        [Test]
        public void BackstagePasses_QualityIncrease()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 15, 20);
            Assert.AreEqual(21, item.Quality);
        }

        /* Checking if Backstage passes quality increases twice 10 days before the show */
        [Test]
        public void BackstagePasses_10DaysBeforeTheConcert_QualityIncreaseTwice()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 10, 20);
            Assert.AreEqual(22, item.Quality);
        }

        /* Checking if Backstage passes quality increases thrice 5 days before the show */
        [Test]
        public void BackstagePasses_5DaysBeforeTheConcert_QualityIncreaseThrice()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 5, 20);
            Assert.AreEqual(23, item.Quality);
        }

        /* Checking if Backstage passes quality drops to 0 after the show */
        [Test]
        public void BackstagePasses_AfterTheConcert_QualityDropsTo0()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 0, 20);
            Assert.AreEqual(0, item.Quality);
        }

        /* Checking if Backstage passes quality can't be more than GildedRose.MaximumQuality even 10 days before the show */
        [Test]
        public void BackstagePasses_10DaysBeforeTheConcert_QualityCantBeMoreThanMaximumQuality()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 10, 49);
            Assert.AreEqual(GildedRose.MaximumQuality, item.Quality);
        }

        /* Checking if Backstage passes quality can't be more then GildedRose.MaximumQuality even 5 days before the show */
        [Test]
        public void BackstagePasses_5DaysBeforeTheConcert_QualityCantBeMoreThanMaximumQuality()
        {
            var item = CreateAndUpdateItem(GildedRose.BackstagePasses, 5, 48);
            Assert.AreEqual(GildedRose.MaximumQuality, item.Quality);
        }
    }
}