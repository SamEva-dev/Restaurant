using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using RestaurantPosMAUI.Data;
using RestaurantPosMAUI.Models;
using System.Collections.ObjectModel;
namespace RestaurantPosMAUI.ViewModels;

public partial class OrderViewModel: ObservableObject
{
    private readonly DatabaseService _databaseService;

    public OrderViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public ObservableCollection<Order> Orders { get; set; } = [];

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

    private bool _initialized;

    [ObservableProperty]
    private bool _isLoading;

    public async Task InitializeAsync()
    {
        if (_initialized)
        {
            return;
        }
        _initialized = true;
        IsLoading = true;

        var orders = await _databaseService.getOrdersAsync();

        foreach (var order in orders)
        {
            Orders.Add(order);
        }
    }
}
