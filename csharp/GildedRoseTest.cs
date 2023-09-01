using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        private const int MAX_QUALITY = 50;

        [Test]
        public void Item_Name_Stays_The_Same_When_Updating_Quality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void Quality_Of_An_Item_Is_Never_Negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.IsFalse(Items[0].Quality < 0);
        }

        [Test]
        public void Aged_Brie_Item_Increases_In_Quality_The_Older_It_Gets()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            var item = Items[0];
            var previousQuality = item.Quality;

            for (int q = 0; q < MAX_QUALITY; ++q)
            {
                app.UpdateQuality();
                Assert.IsTrue(
                    (item.Quality == 50) ||
                    (previousQuality < item.Quality));
                previousQuality = item.Quality;
            }
        }

        [Test]
        public void Quality_Of_An_Item_Is_Never_More_Than_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.IsTrue(Items[0].Quality <= MAX_QUALITY);
        }
    }
}