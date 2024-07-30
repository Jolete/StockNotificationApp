using Microsoft.AspNetCore.SignalR;

namespace StockNotificationApp.StockHub;

public class StockHub : Hub
{
    public async Task NotifyLowStock(string productName, int stock)
    {
        await Clients.All.SendAsync("ReceiveNotification", productName, stock);
    }
}