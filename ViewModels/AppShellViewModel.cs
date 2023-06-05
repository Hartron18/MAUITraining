using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewModels
{
    public partial class AppShellViewModel:ObservableObject
    {
        [RelayCommand]
        public async void OnImageClicked()
        {
            await Shell.Current.GoToAsync(nameof(UserProfilePage));
        }
    }
}
