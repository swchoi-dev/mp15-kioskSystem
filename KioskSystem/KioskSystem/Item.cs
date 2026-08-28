namespace KioskSystem;

public abstract class Item
{
    protected int _id;
    protected string _name;
    protected ItemCategory _itemCategory;
    protected int _price;
    protected Promotion _promotion;
    protected int _count;

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

    public Item(int id, string name, int price, ItemCategory itemCategory, Promotion promotion)
    {
        _id = id;
        _name = name;
        _price = price;
        _itemCategory = itemCategory;
        _promotion = promotion;
        _count = 0;
    }

    public abstract int GetPromotionPrice();
}