using MAUITraining.ViewModels;

namespace MAUITraining.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new PaymentViewModel();
	}
}