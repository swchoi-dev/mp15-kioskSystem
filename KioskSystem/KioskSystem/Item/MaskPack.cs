namespace KioskSystem;

public class MaskPack : Item
{
    public MaskPack(int id, string name, int price, ItemCategory itemCategory, Promotion promotion) :
        base(id, name, price, itemCategory, promotion)
    {
    }
}