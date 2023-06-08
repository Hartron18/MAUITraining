using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views.ShoppingViews;

public partial class CartPage : ContentPage
{
	public CartPage(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}
}