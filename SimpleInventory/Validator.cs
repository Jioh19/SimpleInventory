namespace SimpleInventory;

public static class Validator
{
    private const string Command = "menu";
    private const string MenuText = $"Type '{Command}' to return to the main menu";
    
    public static string? ReadString()
    {
        Console.WriteLine(MenuText);

        while (true)
        {
            var input = Console.ReadLine();

            if (input != null && input.Equals(Command))
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Name cannot be empty or whitespace");
        }
    }
    
    public static decimal ReadDecimal()
    {
        Console.WriteLine(MenuText);
            
        while (true)
        {
            var input = Console.ReadLine();

            if (input != null && input.Equals(Command))
            {
                return 0;
            }

            if (decimal.TryParse(input, out var value))
            {
                if (value > 0)
                {
                    return value;
                }
                Console.WriteLine("Input must be greater than zero");
            }
            else
            {
                Console.WriteLine("Input must be a valid decimal number");
            }
        }
    }
    
    public static int ReadInt(bool menu)
    {
        if (!menu)
        {
            Console.WriteLine(MenuText);
        }

        while (true)
        {
            var input = Console.ReadLine();

            if (input != null && input.Equals(Command))
            {
                return 0;
            }

            if (int.TryParse(input, out var value))
            {
                if (value > 0 || menu)
                {
                    return value;
                }
                Console.WriteLine("Input must be greater than zero");
            }
            else
            {
                Console.WriteLine("Input must be a valid integer number");
            }
        }
    }

    public static bool ReadBool(string field)
    {
        Console.WriteLine($"Update {field}? (y/n): ");
        while (true)
        {
            var input = Console.ReadLine();

            if (input != null && input.Equals("y"))
            {
                return true;
            }
            else if (input != null && input.Equals("n"))
            {
                return false;
            }
            Console.WriteLine("Input must be 'y' or 'n'");
        }
    }
}

