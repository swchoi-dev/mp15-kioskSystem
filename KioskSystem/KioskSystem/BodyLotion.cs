namespace KioskSystem;

public class BodyLotion : Item
{
    public BodyLotion(int id, string name, int price, ItemCategory itemCategory, Promotion promotion) :
        base(id, name, price, itemCategory, promotion)
    {
    }
}