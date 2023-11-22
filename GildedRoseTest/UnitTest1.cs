using GildedRoseLib;

namespace GildedRoseTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void FirstFooTest()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);

        Assert.AreEqual(2, items[0].SellIn);
        Assert.AreEqual(9, items[0].Quality);
    }

    [TestMethod]
    public void FooSellinGoesToZero()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 3);

        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(7, items[0].Quality);
    }    

    [TestMethod]
    public void FooSellinGoesBelowZeroQualityDegradesTwiceAsFast()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 6);

        Assert.AreEqual(-3, items[0].SellIn);
        Assert.AreEqual(1, items[0].Quality);
    }        

    [TestMethod]
    public void FooQualityNeverGoesBelowZero()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 3, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 7);

        Assert.AreEqual(-4, items[0].SellIn);
        Assert.AreEqual(0, items[0].Quality);
    }            

    [TestMethod]
    public void FirstBrieTest()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);

        Assert.AreEqual(2, items[0].SellIn);
        Assert.AreEqual(11, items[0].Quality);
    }

    [TestMethod]
    public void BrieQualityGoesToFifty()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 47 } };
        var app = new GildedRose(items);

        RunMethod(app, 3);

        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(50, items[0].Quality);
    }

    [TestMethod]
    public void BrieQualityNeverGoesAboveFifty()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 47 } };
        var app = new GildedRose(items);

        RunMethod(app, 5);
        Assert.AreEqual(-2, items[0].SellIn);
        Assert.AreEqual(50, items[0].Quality);
    }

    [TestMethod]
    public void SulfurasNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);

        RunMethod(app, 2);
        Assert.AreEqual(0, items[0].SellIn);
        Assert.AreEqual(80, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInGreaterThanTen()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(10, items[0].SellIn);
        Assert.AreEqual(11, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsTen()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(9, items[0].SellIn);
        Assert.AreEqual(12, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsFive()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(4, items[0].SellIn);
        Assert.AreEqual(13, items[0].Quality);
    }

    [TestMethod]
    public void BackstagePassSellInIsZero()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        RunMethod(app, 1);
        Assert.AreEqual(-1, items[0].SellIn);
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