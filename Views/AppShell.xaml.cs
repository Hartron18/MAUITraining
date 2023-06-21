using CommunityToolkit.Mvvm.Messaging;
using MAUITraining.Models;
using MAUITraining.ViewModels;

namespace MAUITraining;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.NotesPage), typeof(Views.NotesPage));
        Routing.RegisterRoute(nameof(Views.UserLoginPage), typeof(Views.UserLoginPage));
        Routing.RegisterRoute(nameof(Views.UserSignUpPage), typeof(Views.UserSignUpPage));
		Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
		Routing.RegisterRoute(nameof(Views.PaymentPage), typeof(Views.PaymentPage));
		Routing.RegisterRoute(nameof(Views.UserProfilePage), typeof(Views.UserProfilePage));
		Routing.RegisterRoute(nameof(CustomControls.clsMenuView), typeof(CustomControls.clsMenuView));
		Routing.RegisterRoute(nameof(Views.CartsPage), typeof(Views.CartsPage));
		Routing.RegisterRoute(nameof(Views.ProductDetaillPage),typeof(Views.ProductDetaillPage));
		Routing.RegisterRoute(nameof(Views.NProductPage), typeof(Views.NProductPage));

		var userLoggedIn = Preferences.Get("IsLoggedIn", false);
		if (userLoggedIn == true)
			MyAppShell.CurrentItem = HomePage;
		//MyAppShell.CurrentItem = LogIn;
		MyAppShell.FlyoutHeader = new FlyoutBehavior() { 
			
		};





    }

	

	
}
