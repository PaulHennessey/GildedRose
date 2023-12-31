using GildedRoseLib;

namespace GildedRoseTest;

[TestClass]
public class UnitTests
{
    [TestMethod]
    public void FirstConjuredTest()
    {
        var items = new List<Item> { new Conjured("Conjured", 3, 16 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);

        Assert.AreEqual(2, items[0].SellIn);
        Assert.AreEqual(14, items[0].Quality);
    }

    [TestMethod]
    public void ConjuredSellinGoesBelowZeroQualityDegradesTwiceAsFast()
    {
        var items = new List<Item> { new Conjured("Conjured", 3, 16 ) };
        var app = new GildedRose(items);

        RunMethod(app, 3);

        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(8, items[0].Quality);
    }        

    [TestMethod]
    public void ConjuredQualityGoesToZero()
    {
        var items = new List<Item> { new Conjured("Conjured", 3, 16 )};
        var app = new GildedRose(items);

        RunMethod(app, 5);

        Assert.AreEqual(-2, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }    

    [TestMethod]
    public void ConjuredQualityNeverGoesBelowZero()
    {
        var items = new List<Item> { new Conjured("Conjured", 3, 16 )};
        var app = new GildedRose(items);

        RunMethod(app, 6);

        Assert.AreEqual(-3, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }    

    [TestMethod]
    public void FirstFooTest()
    {
        var items = new List<Item> { new Item("foo", 3, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);

        Assert.AreEqual(2, items[0].SellIn);
        Assert.AreEqual(9, items[0].Quality);
    }

    [TestMethod]
    public void FooSellinGoesToZero()
    {
        var items = new List<Item> { new Item("foo", 3, 10 )};
        var app = new GildedRose(items);

        RunMethod(app, 3);

        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(6, items[0].Quality);
    }    

    [TestMethod]
    public void FooSellinGoesBelowZeroQualityDegradesTwiceAsFast()
    {
        var items = new List<Item> { new Item("foo", 3, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 6);

        Assert.AreEqual(-3, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }        

    [TestMethod]
    public void FooQualityNeverGoesBelowZero()
    {
        var items = new List<Item> { new Item ("foo", 3, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 7);

        Assert.AreEqual(-4, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }            

    [TestMethod]
    public void FirstBrieTest()
    {
        var items = new List<Item> { new AgedBrie("Aged Brie", 3, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);

        Assert.AreEqual(2, items[0].SellIn);
        Assert.AreEqual(11, items[0].Quality);
    }

    [TestMethod]
    public void BrieQualityGoesToFifty()
    {
        var items = new List<Item> { new AgedBrie("Aged Brie", 3, 47 ) };
        var app = new GildedRose(items);

        RunMethod(app, 3);

        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(50, items[0].Quality);
    }

    [TestMethod]
    public void BrieQualityNeverGoesAboveFifty()
    {
        var items = new List<Item> { new AgedBrie("Aged Brie", 3, 47 ) };
        var app = new GildedRose(items);

        RunMethod(app, 5);
        Assert.AreEqual(-2, items[0].SellIn);
        Assert.AreEqual(50, items[0].Quality);
    }

    [TestMethod]
    public void SulfurasNeverChanges()
    {
        var items = new List<Item> { new Sulfuras ("Sulfuras, Hand of Ragnaros", 0, 80 ) };
        var app = new GildedRose(items);

        RunMethod(app, 2);
        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(80, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInGreaterThanEleven()
    {
        var items = new List<Item> { new BackstagePass ("Backstage passes to a TAFKAL80ETC concert", 12, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(11, items[0].SellIn);
        Assert.AreEqual(11, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsEleven()
    {
        var items = new List<Item> { new BackstagePass ("Backstage passes to a TAFKAL80ETC concert", 11, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(10, items[0].SellIn);
        Assert.AreEqual(12, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsSix()
    {
        var items = new List<Item> { new BackstagePass ("Backstage passes to a TAFKAL80ETC concert", 6, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(5, items[0].SellIn);
        Assert.AreEqual(13, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsOne()
    {
        var items = new List<Item> { new BackstagePass ("Backstage passes to a TAFKAL80ETC concert", 1, 10 ) };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }    

    private void RunMethod(GildedRose app, int count)
    {
        for(int i = 0; i < count; i++)
        {
            app.UpdateQuality();
        }
    }
}