namespace KioskSystem;

public class PlusPromotion : Promotion
{

    public PlusPromotion()
    {
        _name = "1+1 프로모션";
        _description = "2개 구입 시 1개가 무료";
    }
    public override int Price(int price, int count)
    {
        int promotionCount = (count / 2) + (count % 2);
        return price * promotionCount;
    }
}