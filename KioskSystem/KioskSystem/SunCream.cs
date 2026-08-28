namespace KioskSystem;

public class SunCream : Item
{
    public SunCream(int id, string name, int price, ItemCategory itemCategory, Promotion promotion) :
        base(id, name, price, itemCategory, promotion)
    {
        
    }
    
    public override int GetPromotionPrice()
    {
        int tempPrice = _price * _count;
        int reulstPrice = Promotion.Price(tempPrice, _count);
        return reulstPrice;
    }
}