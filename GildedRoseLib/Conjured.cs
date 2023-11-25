namespace GildedRoseLib;

public class Conjured : Item
{
    public Conjured(string name, int sellIn, int quality) : base(name, sellIn, quality)
    {}

    public override void ProcessItem()
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

    protected override void DecrementQuality()
    {      
        if(this.Quality > 0)  
            this.Quality -= 2;
    }            
    
}