﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantPosMAUI.Data;
using RestaurantPosMAUI.Models;
using System.Collections.ObjectModel;
using MenuItem = RestaurantPosMAUI.Data.MenuItem;

namespace RestaurantPosMAUI.ViewModels;

public partial class HomeViewModel: ObservableObject
{
    public DatabaseService _databaseService { get; }

    [ObservableProperty]
    private MenuCategoryModel[] _categories = [];

    [ObservableProperty]
    private MenuItem[] _menuItems = [];

    [ObservableProperty]
    private MenuCategoryModel? _selectedCategory = null;

    public ObservableCollection<CartModel> CartItems { get; set; } = new();

    [ObservableProperty]
    private bool _isLoading;

    public HomeViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
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
        }
    }
}
