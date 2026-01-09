namespace SimpleInventory;

public static class Menu
{
    public static void Exec()
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
            string? input;
            input = Console.ReadLine();
            if (int.TryParse(input, out selection))
            {
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
            }
            Console.WriteLine();
        }
    }

    private static void GetProducts()
    { 
        Inventory.GetProducts();
    }
    
    private static void GetProductByName()
    {
        Console.Write("Enter the product name: "); 
        var input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            Console.WriteLine(Inventory.GetProduct(input));
        }
        else
        {
            Console.WriteLine("Input cannot be empty");
        }
    }

    private static void AddProduct()
    {
        var product = CreateProduct();
        Inventory.AddProduct(product);
    }

    private static Product CreateProduct()
    {

        string name;
        decimal price;
        int quantity;
        while (true)
        {
            Console.Write("Enter the product name: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                name = input;
                break;
            }

            Console.WriteLine("Name cannot be empty or whitespace");
        }
        while (true)
        {
            Console.Write("Enter the product price: ");
            var input = Console.ReadLine();
            if (decimal.TryParse(input, out price))
            {
                break;
            }

            Console.WriteLine("Price must be a number");
        }
        while (true)
        {
            Console.Write("Enter the product quantity: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out quantity))
            {
                break;
            }
            Console.WriteLine("Quantity must be a number");
        }
        return new Product(name, price, quantity);
    }
    
    private static void RemoveProduct()
    {
        while (true)
        {
            Console.Write("Enter the product name: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Inventory.RemoveProduct(input);
                break;
            }
            Console.WriteLine("Name cannot be empty or whitespace");
        }
    }
    
    private static void UpdateProduct()
    {
        Console.Write("Enter the product name: "); 
        var input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            var product = Inventory.GetProduct(input);
            if (product is not null)
            {
                Console.WriteLine("Enter the updated product details");
                Inventory.UpdateProduct(input, CreateProduct());
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