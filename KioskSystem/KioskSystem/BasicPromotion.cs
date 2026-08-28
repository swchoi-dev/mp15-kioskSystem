namespace KioskSystem;

public class BasicPromotion : Promotion
{
    private const int DISCOUNT_RATE = 10;
    private const int DISCOUNT_CONDITION = 3;
    
    public BasicPromotion(string name, string description) : base(name, description)
    {
        
    }

    public override int Price(int price, int count)
    {
        int result = price;
        if (count >= DISCOUNT_CONDITION)
        {
            int discount = price / DISCOUNT_RATE;
            result -= discount;
        }
        return result;
    }
}