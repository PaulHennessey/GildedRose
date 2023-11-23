namespace GildedRoseLib;

public class BackstagePass : Item
{
    public BackstagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {}

    public override void ProcessItem()
    {
        if (QualityLessThanMax())
        {
            IncrementQuality();

            if (SellByDateLessThanXDaysAway(11) && QualityLessThanMax())
            {
                IncrementQuality();
            }

            if (SellByDateLessThanXDaysAway(6) && QualityLessThanMax())
            {
                IncrementQuality();
            }
        }
        
        DecrementSellByDate();

        if (PastSellByDate())
        {
            SetQualityToZero();
        }
    }

    private void SetQualityToZero()
    {
        this.Quality = this.Quality - this.Quality;
    }

    private bool SellByDateLessThanXDaysAway(int days)
    {
        return this.SellIn < days;
    }    
}