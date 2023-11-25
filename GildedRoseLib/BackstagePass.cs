namespace GildedRoseLib;

public class BackstagePass : Item
{
    public BackstagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {}

    public override void ProcessItem()
    {        
        DecrementSellByDate();

        if (PastSellByDate())
        {
            SetQualityToZero();
        }
        else
        {
            if (QualityLessThanMax())
            {
                IncrementQuality();

                if (SellByDateLessThanElevenDaysAway() && QualityLessThanMax())
                {
                    IncrementQuality();
                }

                if (SellByDateLessThanSixDaysAway() && QualityLessThanMax())
                {
                    IncrementQuality();
                }
            }
        }
    }

    private void SetQualityToZero()
    {
        this.Quality = this.Quality - this.Quality;
    }

    private bool SellByDateLessThanElevenDaysAway()
    {
        return this.SellIn < 11;
    }    

    private bool SellByDateLessThanSixDaysAway()
    {
        return this.SellIn < 6;
    }        
}