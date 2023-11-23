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
        foreach(Item item in _items)
        {
            item.ProcessItem();
        }
    }
}