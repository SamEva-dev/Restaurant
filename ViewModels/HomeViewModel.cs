using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantPosMAUI.Data;
using RestaurantPosMAUI.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MenuItem = RestaurantPosMAUI.Data.MenuItem;

namespace RestaurantPosMAUI.ViewModels;

public partial class HomeViewModel: ObservableObject
{
    private readonly DatabaseService _databaseService;

    private readonly OrderViewModel _orderViewModel;

    [ObservableProperty]
    private MenuCategoryModel[] _categories = [];

    [ObservableProperty]
    private MenuItem[] _menuItems = [];

    [ObservableProperty]
    private MenuCategoryModel? _selectedCategory = null;

    public ObservableCollection<CartModel> CartItems { get; set; } = new();

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TaxAmount))]
    [NotifyPropertyChangedFor(nameof(Total))]
    private decimal _subTotal;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TaxAmount))]
    [NotifyPropertyChangedFor(nameof(Total))]
    private int _taxPercentage;

   public decimal TaxAmount => (SubTotal * TaxPercentage) / 100;

    public decimal Total => SubTotal + TaxAmount;

    public HomeViewModel(DatabaseService databaseService, OrderViewModel orderViewModel)
    {
        _databaseService = databaseService;
        _orderViewModel = orderViewModel;
        CartItems.CollectionChanged += CartItems_CollectionChanged;
    }

    private void CartItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        RecalculateAmounts();
    }

    private bool _isInitialized;

    public async Task InitializeAsync()
    {
        if (_isInitialized)
            return;

        _isInitialized = true;

        IsLoading = true;

        Categories = (await _databaseService.GetMenueCategoriesAsync())
            .Select(MenuCategoryModel.FromEntity).ToArray();

        Categories[0].IsSelected = true;
        SelectedCategory = Categories[0];

        MenuItems = await _databaseService.GetMenuItemsByCategoryAsync(SelectedCategory.Id);
        IsLoading = false;
    }

    [RelayCommand]
    private async Task SelectCategoryAsync(int categoryId)
    {
        if (SelectedCategory.Id == categoryId)
            return;
        IsLoading = true;

        var existingSelectedCategory = Categories.First(c => c.IsSelected);
        existingSelectedCategory.IsSelected = false;

        var newLySelectedCategory = Categories.First(c => c.Id == categoryId);
        newLySelectedCategory.IsSelected = true;

        SelectedCategory = newLySelectedCategory;


        MenuItems = await _databaseService.GetMenuItemsByCategoryAsync(categoryId);

        IsLoading = false;
    }

    [RelayCommand]
    private async void AddToCart(MenuItem menuItem)
    {
        var cartItem = CartItems.FirstOrDefault(c => c.ItemId == menuItem.Id);
        if (cartItem == null)
        {
            cartItem = new CartModel()
            {
                ItemId = menuItem.Id,
                Icon = menuItem.Icon,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = 1
            };
            CartItems.Add(cartItem);
        }
        else
        {
            cartItem.Quantity++;
            RecalculateAmounts();
        }
    }

    [RelayCommand]
    private void IncreaseQuantity(CartModel cartItem)
    {
        cartItem.Quantity++;
        RecalculateAmounts();
    }

        [RelayCommand]
    private void DecreaseQuantity(CartModel cartItem)
    {
        cartItem.Quantity--;
        if(cartItem.Quantity == 0)
        {
            CartItems.Remove(cartItem);
        }
        else
            RecalculateAmounts();
    }

    [RelayCommand]
    private void RemoveItemFromCart(CartModel cartItem) => CartItems.Remove(cartItem);

    [RelayCommand]
    private async Task ClearCartAsync()
    {
        if ( await Shell.Current.DisplayAlert("Clear Cart?", "Do you really want to clear the cart?", "Yes", "No"))
        {
            CartItems.Clear();
        }
    }
    private void RecalculateAmounts()
    {
        SubTotal = CartItems.Sum(c => c.Amount);
    }

    [RelayCommand]
    private async Task TaxPercentageClickAsync()
    {
       var result = await Shell.Current.DisplayPromptAsync("Tax Percentage", "Enter the applicable tax percentage", placeholder:"10",initialValue:TaxPercentage.ToString());

        if (!string.IsNullOrWhiteSpace(result))
        {
            if (!int.TryParse(result, out int enteredTaxPercentage))
            {
                await Shell.Current.DisplayAlert("Invalid Value", "Entered tax percentage is invalid", "Ok");
                return;
            }

            if (enteredTaxPercentage > 100)
            {
                await Shell.Current.DisplayAlert("Invalid Valeu", "Tax percentage cannot be more than 100", "Ok");
                return;
            }

            TaxPercentage = enteredTaxPercentage;
        }
    }

    [RelayCommand]
    private async Task PlaceOrderAsync(bool isPaidOnline)
    {
        IsLoading = true;

        if(!await _orderViewModel.PlaceOrderAsync(CartItems.ToArray(), isPaidOnline))
        {
            CartItems.Clear();
        }

        IsLoading = false;
    }
}
