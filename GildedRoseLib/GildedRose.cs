namespace GildedRoseLib;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (QualityShouldDecrease(_items[i]))
            {
                if (_items[i].Quality > 0)
                {
                    if (ItemIsNotLegendary(_items[i]))
                    {
                        _items[i].Quality = _items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (QualityLessThanMax(_items[i]))
                {
                    _items[i].Quality = _items[i].Quality + 1;

                    if (ItemIsBackstagePasses(_items[i]))
                    {
                        if (_items[i].SellIn < 11)
                        {
                            if (QualityLessThanMax(_items[i]))
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }

                        if (_items[i].SellIn < 6)
                        {
                            if (QualityLessThanMax(_items[i]))
                            {
                                _items[i].Quality = _items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (ItemIsNotLegendary(_items[i]))
            {
                _items[i].SellIn = _items[i].SellIn - 1;
            }

            if (SellByDateHasPassed(_items[i]))
            {
                if (ItemIsNotAgedBrie(_items[i]))
                {
                    if (ItemIsNotBackstagePasses(_items[i]))
                    {
                        if (_items[i].Quality > 0)
                        {
                            if (ItemIsNotLegendary(_items[i]))
                            {
                                _items[i].Quality = _items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
                else
                {
                    if (QualityLessThanMax(_items[i]))
                    {
                        _items[i].Quality = _items[i].Quality + 1;
                    }
                }
            }
        }
    }

    private bool QualityShouldDecrease(Item item)
    {
        return item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert";
    }

    private bool ItemIsNotLegendary(Item item)
    {
        return item.Name != "Sulfuras, Hand of Ragnaros";
    }    

    private bool ItemIsNotAgedBrie(Item item)
    {
        return item.Name != "Aged Brie";
    }    

    private bool ItemIsNotBackstagePasses(Item item)
    {
        return item.Name != "Backstage passes to a TAFKAL80ETC concert";
    }    

    private bool ItemIsBackstagePasses(Item item)
    {
        return item.Name == "Backstage passes to a TAFKAL80ETC concert";
    }    

    private bool SellByDateHasPassed(Item item)
    {
        return item.SellIn < 0;
    }    

    private bool QualityLessThanMax(Item item)
    {
        return item.Quality < 50;
    }    
}