using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void QualityDegradesOnePointPerDayForNormalItemsWithinSellByDate()
        {
            var normalItemWithinSellByDate = new Item { Name = "normalItemWithinSellByDate", SellIn = 1, Quality = 10 };
            var originalQuality = normalItemWithinSellByDate.Quality;
            GildedRose app = new GildedRose(new List<Item> { normalItemWithinSellByDate });
            app.UpdateQuality();
            Assert.Equal(originalQuality - 1, normalItemWithinSellByDate.Quality);
        }
        
        [Fact]
        public void QualityDegradesByTwoPointsPerDayForNormalItemsOutOfSellByDate()
        {
            var normalItemOutOfSellByDate = new Item { Name = "normalItemOutOfSellByDate", SellIn = 0, Quality = 10 };
            var originalQuality = normalItemOutOfSellByDate.Quality;
            GildedRose app = new GildedRose(new List<Item> { normalItemOutOfSellByDate });
            app.UpdateQuality();
            Assert.Equal(originalQuality - 2, normalItemOutOfSellByDate.Quality);
        }

        [Fact]
        public void ItemQualityCanNotBeNegative()
        {
            var zeroQualityItem = new Item { Name = "zeroQualityItem", SellIn = 0, Quality = 0 };
            GildedRose app = new GildedRose(new List<Item> { zeroQualityItem });
            app.UpdateQuality();
            Assert.Equal(0, zeroQualityItem.Quality);
        }
        
        [Fact]
        public void SellInDateReducesOnePointPerDay()
        {
            var normalItemWithinSellByDate = new Item { Name = "normalItemWithinSellByDate", SellIn = 1, Quality = 10 };
            var originalSellIn = normalItemWithinSellByDate.SellIn;
            GildedRose app = new GildedRose(new List<Item> { normalItemWithinSellByDate });
            app.UpdateQuality();
            Assert.Equal(originalSellIn - 1, normalItemWithinSellByDate.SellIn);
        }

        [Fact]
        public void AgedBrieIncreasesInQualityOnePointPerDay()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 1, Quality = 10 };
            var originalQuality = agedBrie.Quality;
            GildedRose app = new GildedRose(new List<Item> { agedBrie });
            app.UpdateQuality();
            Assert.Equal(originalQuality + 1, agedBrie.Quality);
        }
    }
}
