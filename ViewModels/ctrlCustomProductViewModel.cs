using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewModels
{
    public partial class ctrlCustomProductViewModel
    {
        public ctrlCustomProductViewModel()
        {
        }

        [RelayCommand]
        public async void ShowPopUp()
        {
            await Shell.Current.DisplayAlert("Demo", "ProductDemo", "Dismiss");
        }
    }
}
