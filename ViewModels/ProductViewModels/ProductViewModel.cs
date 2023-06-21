

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.CustomControls;
using MAUITraining.Models;
using MAUITraining.Services;
using MAUITraining.Views;
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
    public ObservableCollection<Product> products;

    [ObservableProperty]
    public static ObservableCollection<CartProduct> cartProducts;

    private decimal amount = 0;

    [RelayCommand]
    public void AddtoCart(int id)
    {
        var product = Products.Where(x => x.Id == id).FirstOrDefault();
         
        if (CartProducts.Where(x => x.Id == id).Any())
        {
            CartProduct cart = new ()
            {
                CartQuantity = 10,
                Id = id,
                ProductAmount = product.Price * 10,
                Product = product
            };

            CartProducts.Add(cart);
        }

        var oProduct = CartProducts.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        oProduct.CartQuantity += 10;
        oProduct.ProductAmount = product.Price * 10;

    }

    public decimal TotalAmount {
        get { return amount; } 
        private set 
        { 
            for(int i = 0; i < CartProducts.Count; i++) 
            {
                amount += CartProducts[i].ProductAmount;
            }
        } 
    }

    public CartProduct SelectedItem { get; set; }

    public Product Product = new Product();

    private readonly INavigation navigation;


    public void LoadData()
    {
        Products = new ObservableCollection<Product>();
        //Products.Add();

        foreach (Product product in ProductService.Instance.GetProducts())
            Products.Add(product);

    }

    public async void ItemClicked(CartProduct product)
    {
        this.SelectedItem= product;
        await navigation.PushModalAsync(new ProductDetaillPage(this));
    }


    public async void CartItemClicked(Product product)
    {
        //CartProducts[1].Product = product;
        //CartPage cartPage = new CartPage() { BindingContext = this };
        
        await navigation.PushModalAsync(new CartsPage(this));
    }

    [RelayCommand]
    public async void ShowProducts()
    {
        await Shell.Current.GoToAsync(nameof(NProductPage));
        
    }

    
}

