namespace KioskSystem;

public class Shampoo : Item
{
    public Shampoo(int id, string name, int price, ItemCategory itemCategory, Promotion promotion) :
        base(id, name, price, itemCategory, promotion)
    {
        
    }
}