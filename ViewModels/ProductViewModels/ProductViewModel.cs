

using CommunityToolkit.Mvvm.ComponentModel;
using MAUITraining.Models;
using MAUITraining.Services;
using MAUITraining.Views.ShoppingViews;
using System.Collections.ObjectModel;

namespace MAUITraining.ViewModels.ProductViewModels;

public partial class ProductViewModel:ObservableObject
{
    public ProductViewModel(INavigation navigation)
    {
        LoadData();
        this.navigation = navigation;
    }

    public ProductViewModel()
    {
        LoadData();
    }

    [ObservableProperty]
    public ObservableCollection<CartProduct> products;
    [ObservableProperty]
    public static ObservableCollection<CartProduct> cartProducts;

    public CartProduct SelectedItem { get; set; }

    private INavigation navigation;


    public void LoadData()
    {
        Products = new ObservableCollection<CartProduct>();
        //Products.Add();

        foreach (CartProduct product in ProductService.Instance.GetProducts())
            Products.Add(product);

    }

    public async void ItemClicked(CartProduct product)
    {
        this.SelectedItem= product;
        await navigation.PushModalAsync(new ProductDetailPage(this));
    }


    public async void CartItemClicked(CartProduct product)
    {
        CartProducts.Add(product);
        //CartPage cartPage = new CartPage() { BindingContext = this };
        
        await navigation.PushModalAsync(new CartPage(this));
    }
}

