using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.Views.ShoppingViews;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(ProductViewModel product)
	{
		InitializeComponent();
		BindingContext= product;
	}
}