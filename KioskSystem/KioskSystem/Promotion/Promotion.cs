namespace KioskSystem;

public abstract class Promotion
{
    protected string _name;
    protected string _description;

    public string Name => _name;
    public string Description => _description;
    
    public Promotion()
    {
    }

    public abstract int Price(int price, int count);
}