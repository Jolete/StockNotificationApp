using Microsoft.AspNetCore.SignalR;
using StockNotificationApp.Models;

namespace StockNotificationApp.StockHub;

public class StockChecker
{
    private readonly IHubContext<StockHub> _hubContext;

    public StockChecker(IHubContext<StockHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public void CheckStock(List<Product> products, int minimumQuantity)
    {
        foreach (var product in products)
        {
            if (product.Stock < minimumQuantity)
            {
                _hubContext.Clients.All.SendAsync("ReceiveNotification", product.Name, product.Stock);
            }
        }
    }
}