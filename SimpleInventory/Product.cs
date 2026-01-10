namespace SimpleInventory;

public class Product(string name, decimal price, int quantity)
{
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;

    public override string ToString()
    {
        return "\n" + "".PadLeft(28, '*') + $"\n** {nameof(Name),10:D}: " +
               $"{Name,-10} **\n** {nameof(Price),10:D}: {Price,-10:F2} **\n** {nameof(Quantity),10:D}:" +
               $" {Quantity,-10} **\n" + "".PadLeft(28, '*');
    }
}