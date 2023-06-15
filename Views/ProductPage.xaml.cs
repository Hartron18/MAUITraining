using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views;

public partial class ProductPage : ContentPage
{
	public ProductPage(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}

    public ProductViewModel product = new ();
    public ProductPage()
    {
        InitializeComponent();
        BindingContext = product;
    }
}