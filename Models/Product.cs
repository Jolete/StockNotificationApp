namespace StockNotificationApp.Models;

public class Product
{
    public string Name { get; set; }
    public int Stock { get; set; }

    public Product(string name, int stock)
    {
        Name = name;
        Stock = stock;
    }
}


