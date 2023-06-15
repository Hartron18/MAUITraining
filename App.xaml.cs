namespace MAUITraining;

public partial class App : Application
{
	public App()
	{

        InitializeComponent();
        MainPage = new AppShell();
		MainPage.FlowDirection = FlowDirection.LeftToRight;
		
	}

	public static string BaseUrl = "";
}
