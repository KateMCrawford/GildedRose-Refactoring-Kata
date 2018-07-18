using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void ExampleTest()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void Generic_QualityDegrades()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void Generic_QualityDegradesFasterAfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void Conjured_QualityDegrades()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void Conjured_QualityDegradesFasterAfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(6, Items[0].Quality);
        }

        [Test]
        public void Legendary_QualityStaysAt80()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void AgedBrie_QualityIncreasesBeforeSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void AgedBrie_QualityIncreasesAfterSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void BackstageTickets_QualityIncreasesByOneBeforeTenDays()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(11, Items[0].Quality);
        }

        [Test]
        public void BackstageTickets_QualityIncreasesByTwoBeforeFiveDays()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 10}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(12, Items[0].Quality);
        }

        [Test]
        public void BackstageTickets_QualityIncreasesByThreeBeforeSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(13, Items[0].Quality);
        }


        [Test]
        public void BackstageTickets_QualityZeroAfterSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateItem();
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
