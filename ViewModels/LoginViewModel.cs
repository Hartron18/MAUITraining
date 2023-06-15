
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MAUITraining.Models;
using MAUITraining.Views;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Diagnostics;
using System.Text;


namespace MAUITraining.ViewModels
{
    
    internal partial class LoginViewModel:ObservableObject
    {
        HttpClient _httpClient;

        private PeriodicTimer timer = new (TimeSpan.FromMinutes(1));
        

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

                string baseUrl = "https://vmd4xjv8-5001.uks1.devtunnels.ms/";

                HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}api/User/login", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\login successfully.");

                    await Shell.Current.GoToAsync(nameof(NotesPage));

                    Preferences.Set("IsLoggedIn", true);
                    

                    //timer = new PeriodicTimer(time);
                    //if (time.TotalMinutes == 1)
                    //{
                    //    SignOut();
                    //}

                }
                    
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Could not login {ex.Message}");
            }

            
            
        }

        [RelayCommand]
        protected async Task OnBiometric()
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
                    await Shell.Current.GoToAsync(nameof(HomePage));

                    //PeriodicTimer time = new PeriodicTimer(timeCount);    
                    
                    Preferences.Set("IsLoggedIn", true);
                    CancellationToken token = new CancellationToken();
                    while (await timer.WaitForNextTickAsync(token) 
                        && !token.IsCancellationRequested)
                    {
                        while (App.Current.Windows.Where( x => x.Page.IsFocused == true).Any())
                        {
                            timer.Dispose();
                        }
                        await SignOut();
                        timer.Dispose();
                        
                    }
                    
                }
                else
                {
                    await Shell.Current.DisplayAlert("Authentication failed", "Access Denied", "Try again or login with email");
                }

            }  
        }

        [RelayCommand]
        public void SignUpPage()
        {
            Shell.Current.GoToAsync(nameof(UserSignUpPage));
        }

        public async Task SignOut()
        {

            await Shell.Current.GoToAsync(nameof(UserLoginPage));
            Preferences.Clear("IsLoggedIn");
        }

        //LogIn loginn = WeakReferenceMessenger.Default.Register<>();
    }
}
