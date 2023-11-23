namespace GildedRoseLib;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    public Item(string name, int sellIn, int quality)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
    }

    public virtual void ProcessItem()
    {
        if (QualityGreaterThanZero())
        {
            DecrementQuality();
        }
        else if (QualityLessThanMax())
        {
            IncrementQuality();
        }
        
        DecrementSellByDate();

        if (PastSellByDate())
        {
            if (QualityGreaterThanZero())
            {
                DecrementQuality();
            }
        }
    }

    protected void IncrementQuality()
    {
        this.Quality += 1;
    }

    protected void DecrementSellByDate()
    {
        this.SellIn -= 1;
    }    

    protected bool PastSellByDate()
    {
        return this.SellIn < 0;
    }    

    protected bool QualityLessThanMax()
    {
        return this.Quality < 50;
    }

    private void DecrementQuality()
    {
        this.Quality -= 1;
    }    

    private bool QualityGreaterThanZero()
    {
        return this.Quality > 0;
    }            
}