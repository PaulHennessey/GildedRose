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
        DecrementSellByDate();

        if (PastSellByDate())
        {
            DecrementQuality();
            DecrementQuality();
        }
        else
        {
            DecrementQuality();
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
        return this.SellIn <= 0;
    }    

    protected bool QualityLessThanMax()
    {
        return this.Quality < 50;
    }

    protected virtual void DecrementQuality()
    {      
        if(this.Quality > 0)  
            this.Quality -= 1;
    }    
}