

using CommunityToolkit.Mvvm.ComponentModel;
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

    private INavigation navigation;


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

    public void AddtoCart(Product product,int cartQuantity)
    {
        var cartoProduct = CartProducts.Where(x => x.Product.Id == product.Id).Any();
        if (cartoProduct == false)
        {
            CartProduct cart = new CartProduct
            {
                CartQuantity = cartQuantity,
                Id = product.Id,
                ProductAmount = product.Price * cartQuantity,
                Product = product
            };

            CartProducts.Add(cart);
        }

        var oProduct = CartProducts.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        oProduct.CartQuantity += cartQuantity;
        oProduct.ProductAmount = product.Price * cartQuantity;
        
    }
}

