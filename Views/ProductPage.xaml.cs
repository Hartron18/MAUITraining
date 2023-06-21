using MAUITraining.CustomControls;
using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views;

public partial class ProductPage : ContentPage
{
   
    public ProductPage(ProductViewModel item)
	{
        product = item;
        //ProductGrid.Children.Add(new ctrlclsProduct(product));
        InitializeComponent();
		BindingContext= item;
        
	}

    public ProductViewModel product = new();

    public ProductPage()
    {
        //ProductGrid.Children.Add(new ctrlclsProduct(product));
        InitializeComponent();
        BindingContext = product;
    }
}