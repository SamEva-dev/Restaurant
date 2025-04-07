using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantPosMAUI.Data;
using RestaurantPosMAUI.Models;
namespace RestaurantPosMAUI.ViewModels;

public partial class OrderViewModel: ObservableObject
{
    private readonly DatabaseService _databaseService;

    public OrderViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public async Task<bool> PlaceOrderAsync(CartModel[] cartItems, bool isOnline)
    {
        var orderItems = cartItems.Select(c => new OrderItem
        {
            Icon = c.Icon,
            ItemId = c.ItemId,
            Name = c.Name,
            Price = c.Price,
            Quantity = c.Quantity,
        }).ToArray();

        var orderModel = new OrderModel()
        {
            OrderDate = DateTime.Now,
            PaymentMode = isOnline ? "Online" : "Cash",
            TotalAmountPaid = cartItems.Sum(c => c.Amount),
            TotalItemsCount = cartItems.Length,
            Items = orderItems
        };

        var errorMessage = await _databaseService.PlaceOrderAsync(orderModel);

        if (!string.IsNullOrEmpty(errorMessage))
        {
            await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
            return false;
        }

        await Toast.Make("order placed successfully").Show();
        return true;
    }
}
