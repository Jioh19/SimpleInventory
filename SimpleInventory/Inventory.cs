namespace SimpleInventory;

public class Inventory
{
    private readonly List<Product> _products = [];
    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    
    public List<Product> GetProducts()
    {
        return _products;
    }
    
    public Product? GetProduct(string name)
    {
        return _products.Find(p => p.Name.Equals(name));
    }
    
    public void RemoveProduct(string name)
    {
        _products.RemoveAll(p => p.Name.Equals(name));
    }

    public void UpdateProduct(string name, Product product)
    {
        var index = _products.FindIndex(p => p.Name.Equals(name));
        if (index != -1)
        {
            _products[index] = product;
        }
    }
}