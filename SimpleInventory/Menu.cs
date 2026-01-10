namespace SimpleInventory;

public class Menu(Inventory inventory)
{
    public void Exec()
    {
        var selection = 1;
        while (selection is not 0)
        {
            Console.WriteLine("Simple Inventory Management System");
            Console.WriteLine("1. Get All Products");
            Console.WriteLine("2. Get Product By Name");
            Console.WriteLine("3. Add Product");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Update Product");
            Console.WriteLine("0. Exit");
            selection = Validator.ReadInt(true);

            switch (selection)
            {
                case 0:
                    Console.WriteLine("Exiting");
                    break;
                case 1:
                    GetProducts();
                    break;
                case 2:
                    GetProductByName();
                    break;
                case 3:
                    AddProduct();
                    break;
                case 4:
                    RemoveProduct();
                    break;
                case 5:
                    UpdateProduct();
                    break;
                default:
                {
                    Console.WriteLine("Invalid selection");
                    break;
                }
            }
            Console.WriteLine();
        }
    }

    private void GetProducts()
    { 
        var products = inventory.GetProducts();
        if (products.Count is 0)
        {
            Console.WriteLine("No products in inventory");
        }
        else
        {
            products.ForEach(Console.WriteLine);
        }
    }
    
    private void GetProductByName()
    {
        Console.WriteLine("Enter the product name: ");
        var name = Validator.ReadString();
        if (name is null)
        {
            return;
        }
        var product = inventory.GetProduct(name);
        
        if (product is not null)
        {
            Console.WriteLine(product);
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }

    private void AddProduct()
    {
        var product = CreateProduct();
        if (product is not null)
        {
            inventory.AddProduct(product);
            Console.WriteLine("Product added successfully");
        }
        else
        {
            Console.WriteLine("Product creation cancelled");
        }
    }

    private Product? CreateProduct()
    {
        Console.WriteLine("Enter the product name: ");
        var name = Validator.ReadString();
        if (name is null)
        {
            return null;
        }

        Console.WriteLine("Enter the product price: ");
        var price = Validator.ReadDecimal();
        if (price is 0)
        {
            return null;
        }
        
        Console.WriteLine("Enter the product quantity: ");
        var quantity = Validator.ReadInt(false);
        if (quantity is 0)
        {
            return null;
        }
        
        return new Product(name, price, quantity);
    }
    
    private void RemoveProduct()
    {

        Console.WriteLine("Enter the product name: ");
        var name = Validator.ReadString();
        if (name is null)
        {
            return;
        }

        if (inventory.GetProduct(name) is null)
        {
            Console.WriteLine("Product not found");
            return;
        }
        inventory.RemoveProduct(name);
        Console.WriteLine("Product removed successfully");

    }
    
    private void UpdateProduct()
    {
        Console.WriteLine("Enter the product name: ");
        var name = Validator.ReadString();
        if (name is null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(name))
        {
            var product = inventory.GetProduct(name);
            if (product is not null)
            {
                Console.WriteLine("Enter the updated product details");
                var updatedProduct = CreateProduct();
                if (updatedProduct is not null)
                {
                    inventory.UpdateProduct(name, updatedProduct);
                    Console.WriteLine("Product updated successfully");
                }
                else
                {
                    Console.WriteLine("Product update cancelled");
                }
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }
        else
        {
            Console.WriteLine("Input cannot be empty");
        }
    }
}