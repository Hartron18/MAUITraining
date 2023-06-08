using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views.ShoppingViews;

public partial class ProductViews : ContentPage
{
	public ProductViews(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}
}