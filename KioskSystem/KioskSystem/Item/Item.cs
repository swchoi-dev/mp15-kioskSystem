namespace KioskSystem;

public abstract class Item
{
    protected int _count;
    protected int _id;
    protected ItemCategory _itemCategory;
    protected string _name;
    protected int _price;
    protected Promotion _promotion;

    public Item(int id, string name, int price, ItemCategory itemCategory, Promotion promotion)
    {
        _id = id;
        _name = name;
        _price = price;
        _itemCategory = itemCategory;
        _promotion = promotion;
        _count = 0;
    }

    public int Id => _id;
    public string Name => _name;
    public ItemCategory ItemCategory => _itemCategory;
    public int Price => _price;
    public Promotion Promotion => _promotion;

    public int Count
    {
        get => _count;
        set => _count = value;
    }

    public virtual int GetPromotionPrice()
    {
        var reulstPrice = Promotion.Price(_price, _count);
        return reulstPrice;
    }
}