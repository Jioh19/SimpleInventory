namespace SimpleInventory;

public static class Inventory
{
    private static readonly List<Product> Products = [];

    public static void AddProduct(Product product)
    {
        Products.Add(product);
    }
    
    public static void GetProducts()
    {
        Products.ForEach(Console.WriteLine);
    }
    
    public static Product? GetProduct(string name)
    {
        return Products.Find(p => p.Name.Equals(name));
    }

    public static void RemoveProduct(string name)
    {
        Products.RemoveAll(p => p.Name.Equals(name));
    }
    
    public static void UpdateProduct(string name, Product product)
    {
        var index = Products.FindIndex(p => p.Name.Equals(name));
        if (index != -1)
        {
            Products[index] = product;
        }
    }
}