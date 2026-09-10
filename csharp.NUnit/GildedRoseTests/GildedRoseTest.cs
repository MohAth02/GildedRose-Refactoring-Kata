using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]

    public void testAgedBrieIncrease()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1000, Quality = 0 } };
        var app = new GildedRose(items);
        for (var i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].Quality, Is.EqualTo(5));
    }


    [Test]
    public void testAgedBrieIncreaseByTwoafterSellInExpires()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        for (var i = 0; i < 5; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].Quality, Is.EqualTo(10));
    }

    [Test]
    public void testSulfurasQualityStayAt80()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
        var app = new GildedRose(items);
        for (var i = 0; i <= 15; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].Quality, Is.EqualTo(80));
    }


    [Test]
    public void testBackstagePassesSellingStaysTheSame()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);
        for (var i = 0; i <= 15; i++)
        {
            app.UpdateQuality();
        }

        Assert.That(items[0].SellIn, Is.EqualTo(15));
    }
}