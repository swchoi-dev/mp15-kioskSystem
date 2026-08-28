namespace KioskSystem;

public class EmptyPromotion : Promotion
{
    public EmptyPromotion()
    {
        _name = "프로모션 없음";
        _description = "정가";
    }

    public override int Price(int price, int count)
    {
        var result = price * count;
        return result;
    }
}