namespace KioskSystem;

public class BigSalePromotion : Promotion
{
    private const int DISCOUNT_AMOUNT = 1000;
    private const int DISCOUNT_CONDITION = 10;

    public BigSalePromotion()
    {
        _name = "빅 세일 프로모션";
        _description = "10개 이상 구매 시 개당 1000원 할인";
    }

    public override int Price(int price, int count)
    {
        var result = price * count;
        if (count < DISCOUNT_CONDITION) return result;

        result = (price - DISCOUNT_AMOUNT) * count;
        return result;
    }
}