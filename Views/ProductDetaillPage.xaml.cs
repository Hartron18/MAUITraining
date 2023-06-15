using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views;

public partial class ProductDetaillPage : ContentPage
{
	public ProductDetaillPage(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}
}