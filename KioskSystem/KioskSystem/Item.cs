namespace KioskSystem;

public abstract class Item
{
    protected int _id;
    protected string _name;
    protected ItemCategory _itemCategory;
    protected int _price;

    public int Id => _id;
    public string Name => _name;
    public ItemCategory ItemCategory => _itemCategory;
    public int Price => _price;
    
    public Item(int id, string name, int price, ItemCategory itemCategory)
    {
        _id = id;
        _name = name;
        _price = price;
        _itemCategory = itemCategory;
    }
}