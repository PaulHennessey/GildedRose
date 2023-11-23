namespace GildedRoseLib;

public class AgedBrie : Item
{
    public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {}

    public override void ProcessItem()
    {
        if (QualityLessThanMax())
        {
            IncrementQuality();
        }
        
        DecrementSellByDate();

        if (PastSellByDate())
        {
            if (QualityLessThanMax())
            {
                IncrementQuality();
            }
        }
    }
}