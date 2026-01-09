namespace SimpleInventory;

public class Product(string name, decimal price, int quantity)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Quantity)}: {Quantity}";
    }
}