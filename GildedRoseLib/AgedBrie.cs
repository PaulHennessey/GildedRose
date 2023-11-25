namespace GildedRoseLib;

public class AgedBrie : Item
{
    public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {}

    public override void ProcessItem()
    {
        DecrementSellByDate();

        if (QualityLessThanMax())
        {
            IncrementQuality();
        }
        
        if (QualityLessThanMax() && PastSellByDate())
        {
            IncrementQuality();
        }
    }
}