namespace MAUITraining.Views;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
		string source = "https://9bbr0gtr-5001.uks1.devtunnels.ms/api/PaymentPaysta";
		var wv = new WebView();
		content.Content= wv;
		wv.Source= source;
	}
}