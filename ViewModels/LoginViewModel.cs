
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;
using MAUITraining.Views;
using Newtonsoft.Json;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace MAUITraining.ViewModels
{
    internal partial class LoginViewModel:ObservableObject
    {
        HttpClient _httpClient;

        private readonly IFingerprint fingerprint;

        [ObservableProperty]
        public LogIn login;
        [ObservableProperty]
        public string email;
        [ObservableProperty]
        public string password;
       

        public LoginViewModel(IFingerprint fingerprint)
        {
            Login= new ();
            this.fingerprint = fingerprint;

        }

        public LoginViewModel()
        {
            Login = new();
        }

        [RelayCommand]
        public async Task LogIn()
        {
            
            try
            {
                Login.Email = Email;
                Login.Password = Password;

                _httpClient = new();
                string json = JsonConvert.SerializeObject(Login);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                string baseUrl = "https://54slpv6x-5001.uks1.devtunnels.ms/";

                HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}api/User/login", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\login successfully.");

                    await Shell.Current.GoToAsync(nameof(NotesPage));
                    
                }
                    
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Could not login {ex.Message}");
            }
            
        }

        [RelayCommand]
        protected async void OnBiometric()
        {
            bool isAvailable = await fingerprint.IsAvailableAsync();

            if (isAvailable)
            {
                var request = new AuthenticationRequestConfiguration("Fingerprint validation", "Validate with your fingerprint")
                {
                    FallbackTitle = "Use Pin",
                    AllowAlternativeAuthentication = true
                };
                var result = await fingerprint.AuthenticateAsync(request);

                if (result.Authenticated)
                {
                    //await Shell.Current.DisplayAlert("Authentication Successful", "Access Granted", "Continue");
                    await Shell.Current.GoToAsync(nameof(PaymentPage));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Authentication failed", "Access Denied", "Try again or login with email");
                }
            }  
        }
    }
}
