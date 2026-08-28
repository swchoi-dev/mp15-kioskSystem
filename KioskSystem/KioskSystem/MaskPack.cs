namespace KioskSystem;

public class MaskPack : Item
{
    public MaskPack(int id, string name, int price, ItemCategory itemCategory, Promotion promotion) :
        base(id, name, price, itemCategory, promotion)
    {
    }

    public override int GetPromotionPrice()
    {
        Console.WriteLine($"{_price} / {_count}");
        int tempPrice = _price * _count;
        int reulstPrice = Promotion.Price(tempPrice, _count);
        return reulstPrice;
    }
}