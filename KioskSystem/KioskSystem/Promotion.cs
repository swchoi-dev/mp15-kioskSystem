namespace KioskSystem;

public abstract class Promotion
{
    private string _name;
    private string _description;

    public string Name => _name;
    public string Description => _description;
    
    public Promotion(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public abstract int Price(int price, int count);
}