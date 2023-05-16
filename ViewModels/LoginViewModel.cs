
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

        public async Task LogIn()
        {
            
            try
            {
                Login.Email = Email;
                Login.Password = Password;

                _httpClient = new();
                string json = JsonConvert.SerializeObject(Login);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                string baseUrl = "https://fr4c3dn5-5001.uks1.devtunnels.ms/";

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
        private async void OnBiometric()
        {
            var request = new AuthenticationRequestConfiguration("Fingerprint validation", "Validate with your fingerprint");
            var result = await fingerprint.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                await Shell.Current.DisplayAlert("Authentication Successful", "Access Granted", "Continue");
                await Shell.Current.GoToAsync(nameof(HomePage));
            }

            await Shell.Current.DisplayAlert("Authentication failed", "Access Denied", "Try again");
        }
    }
}
