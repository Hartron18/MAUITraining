using MAUITraining.ViewModels;
using Plugin.Fingerprint;

namespace MAUITraining.Views;

public partial class UserLoginPage : ContentPage
{
	
    public UserLoginPage()
    {

        InitializeComponent();
        if (!DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
        {
            BindingContext = new LoginViewModel(CrossFingerprint.Current);
        }
        else
        {
            BindingContext = new LoginViewModel();
        }
        

    }
}