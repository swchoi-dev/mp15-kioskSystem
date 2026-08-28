namespace KioskSystem;

public class BasicPromotion : Promotion
{
    private const int DISCOUNT_RATE = 10;
    private const int DISCOUNT_CONDITION = 3;
    
    public BasicPromotion()
    {
        _name = "기본할인";
        _description = "3개 이상 10% 할인";
    }

    public override int Price(int price, int count)
    {
        int result = price * count;
        if (count < DISCOUNT_CONDITION)
        {
            return result;
        }
        
        int discount = result / DISCOUNT_RATE;
        result -= discount;
        
        return result;
    }
}