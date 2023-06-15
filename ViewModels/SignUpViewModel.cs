using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;
using MAUITraining.Views;
using Newtonsoft.Json;
using Plugin.Fingerprint.Abstractions;
using System.Diagnostics;
using System.Text;


namespace MAUITraining.ViewModels
{
    public partial class SignUpViewModel: ObservableObject
    {
        [ObservableProperty]
        private SignUp user;

        HttpClient _httpClient;
       
        public SignUpViewModel()
        {
            User = new SignUp();
            
            //SignUpCommand = new AsyncRelayCommand(SignUp);
        }
        [ObservableProperty]
        public string email;
        [ObservableProperty]
        public string displayName;
        [ObservableProperty]
        public string password;
        //[ObservableProperty]
        //public string firstName;
        //[ObservableProperty]
        //public string lastName;

        [RelayCommand]
        public async Task SignUp()
        {
            if (User == null) { }
            
            try
            {
                User.Email = Email;
                User.Password = Password;
                User.DisplayName = DisplayName;

                _httpClient = new();
                string json = JsonConvert.SerializeObject(User);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                string baseUrl = "https://vmd4xjv8-5001.uks1.devtunnels.ms/";

                HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}api/Account/register", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\login successfully.");

                    await Shell.Current.GoToAsync(nameof(UserLoginPage));
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"registration failed {ex.Message}");
            }

        }

        [RelayCommand]
        public void LoginPage()
        {
            Shell.Current.GoToAsync($"//{nameof(UserLoginPage)}");
        }

        
    }
}
