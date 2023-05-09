namespace MAUITraining.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
		if(BindingContext is Models.About about)
		{
			//Navigate to the specified url inn the system browser
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}