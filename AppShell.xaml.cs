using MAUITraining.Models;

namespace MAUITraining;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		
		Routing.RegisterRoute(nameof(Views.NotesPage), typeof(Views.NotesPage));
        Routing.RegisterRoute(nameof(Views.UserLoginPage), typeof(Views.UserLoginPage));
        Routing.RegisterRoute(nameof(Views.UserSignUpPage), typeof(Views.UserSignUpPage));
		
		
    }
}
