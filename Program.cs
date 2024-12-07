class Program
{
  static List<Product> inventory = new List<Product>();

  static void Main(string[] args)
  {
    Console.Clear();
    bool exit = false;
    while (!exit)
    {
      Console.WriteLine("Inventory Management System");
      Console.WriteLine("1. Add product");
      Console.WriteLine("2. Update stock");
      Console.WriteLine("3. View inventory");
      Console.WriteLine("4. Remove product");
      Console.WriteLine("5. Exit");

      Console.Write("Enter your choice: ");
      string? input = Console.ReadLine();
      if (!int.TryParse(input, out int choice))
      {
        Console.Clear();
        Console.WriteLine("Invalid choice. Please enter a number.");
        Console.WriteLine();
        continue;
      }

      switch (choice)
      {
        case 1:
          AddProduct();
          break;
        case 2:
          UpdateStock();
          break;
        case 3:
          ViewInventory();
          break;
        case 4:
          RemoveProduct();
          break;
        case 5:
          exit = true;
          break;
        default:
          Console.Clear();
          Console.WriteLine("Invalid choice.");
          Console.WriteLine();
          break;
      }
    }
  }

  static void AddProduct()
  {
    Console.Clear();
    Console.Write("Enter product name: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
      Console.WriteLine("Product name cannot be empty.");
      Console.WriteLine();
      return;
    }

    Console.Write("Enter product price: ");
    if (!double.TryParse(Console.ReadLine(), out double price))
    {
      Console.WriteLine("Invalid price. Please enter a number.");
      Console.WriteLine();
      return;
    }

    Console.Write("Enter product quantity: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity))
    {
      Console.WriteLine("Invalid quantity. Please enter a number.");
      Console.WriteLine();
      return;
    }

    inventory.Add(new Product { Name = name, Price = price, Quantity = quantity });
    Console.Clear();
    Console.WriteLine("Product added successfully.");
    Console.WriteLine();
  }

  static void UpdateStock()
  {
    Console.WriteLine("Select a product to update:");
    ViewInventory();

    if (inventory.Count == 0)
    {
      return;
    }

    Console.Write("Enter product index: ");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= inventory.Count)
    {
      Console.WriteLine("Invalid index.");
      Console.WriteLine();
      return;
    }

    Console.Write("Enter new quantity: ");
    if (!int.TryParse(Console.ReadLine(), out int newQuantity))
    {
      Console.WriteLine("Invalid quantity.");
      Console.WriteLine();
      return;
    }

    inventory[index].Quantity = newQuantity;
    Console.Clear();
    Console.WriteLine("Stock updated successfully.");
    Console.WriteLine();
  }

  static void ViewInventory()
  {
    Console.Clear();
    if (inventory.Count == 0)
    {
      Console.WriteLine("Inventory is empty.");
      Console.WriteLine();
      return;
    }

    Console.WriteLine("Product Inventory:");
    Console.WriteLine("Index\tName\tPrice\tQuantity");
    for (int i = 0; i < inventory.Count; i++)
    {
      Console.WriteLine($"{i}\t{inventory[i].Name}\t{inventory[i].Price}\t{inventory[i].Quantity}");
    }
    Console.WriteLine();
  }

  static void RemoveProduct()
  {
    Console.Clear();
    Console.WriteLine("Select a product to remove:");
    ViewInventory();

    if (inventory.Count == 0)
    {
      return;
    }

    Console.Write("Enter product index: ");
    if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= inventory.Count)
    {
      Console.WriteLine("Invalid index.");
      Console.WriteLine();
      return;
    }

    inventory.RemoveAt(index);
    Console.Clear();
    Console.WriteLine("Product removed successfully.");
    Console.WriteLine();
  }
}

class Product
{
  public string Name { get; set; } = string.Empty;
  public double Price { get; set; }
  public int Quantity { get; set; }
}