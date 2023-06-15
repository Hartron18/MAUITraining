using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views;

public partial class CartsPage : ContentPage
{
	public CartsPage(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}
}