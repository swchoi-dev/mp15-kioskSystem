namespace KioskSystem;

public class BasicPromotion : Promotion
{
    public BasicPromotion(string name, string description) : base(name, description)
    {
        
    }

    public override int PromotionPrice(int price, int count)
    {
        return price;
    }
}