using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;
using MAUITraining.Services;
using MAUITraining.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewModels
{
    public partial class DynamenViewModel: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<DynamenItem> menuItems;
        [ObservableProperty]
        public string title;

        public  void LoadMenuItems()
        {
            Title = DynamenService.Title;
            MenuItems = new ObservableCollection<DynamenItem>();
            
            foreach (DynamenItem menuItem in DynamenService.Instance.GetDynamenItems())
                MenuItems.Add(menuItem);
                        
        }

        [RelayCommand]
        public async void GotoProductPage()
        {
            await Shell.Current.GoToAsync(nameof(NProductPage));
        }
    }
}
