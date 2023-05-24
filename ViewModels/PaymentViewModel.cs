using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;
using MAUITraining.Views;
using Newtonsoft.Json;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewModels
{
    internal partial class PaymentViewModel: ObservableObject
    {
        HttpClient client;
        //[ObservableProperty]
        PaymentInfo payment;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string email;
        [ObservableProperty]
        double amount;
        [ObservableProperty]
        string redirectUrl;
        [ObservableProperty]
        string userGUID;

        public PaymentViewModel()
        {
            this.payment = new PaymentInfo();
        }

        [RelayCommand]
        public async void Pay()
        {
            payment = new PaymentInfo
            {
                Amount= Amount,
                Email= Email,
                UserGUID= UserGUID,
                RedirectUrl= RedirectUrl,
                Name= Name,
            };
            string baseUrl = "https://54slpv6x-5001.uks1.devtunnels.ms/";
            client = new HttpClient();
            string uri = baseUrl + "api/PaymentPaystack";
            string json = JsonConvert.SerializeObject(payment);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            var makePayment = await client.PostAsync(uri, content);
            if(makePayment.IsSuccessStatusCode)
            {
                await Shell.Current.GoToAsync(nameof(HomePage));

            }
        }

        string text = "https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/data/share?tabs=android";

        [RelayCommand]
        public async void ShareLink(string uri)
        {
            
            uri = text;
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Share",
                Text = uri
            });
        }

        [RelayCommand]
        public async void ToastNotification(CancellationTokenSource token)
        {
            token = new CancellationTokenSource();

            string text = "Toast Me";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 12;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show();
        }

        [RelayCommand]
        public async void SnackbarNotification(CancellationTokenSource token)
        {
            token = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Chocolate,
                TextColor = Colors.Yellow,
                ActionButtonTextColor = Colors.White,
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(12),
                CornerRadius = new CornerRadius(10)
            };

            string text = "Give me a Snack bar";
            string actionButtonText = "Dismiss";
            Action action = null;
            TimeSpan duration = TimeSpan.FromSeconds(3);

            var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(token.Token);

            Shell.Current.DisplaySnackbar("Snackbar 2", action, actionButtonText, duration);
        }

        //[RelayCommand]
        //public async void Notificationn()
        //{

        //}

        [RelayCommand]
        public void PopupNotification()
        {
            Shell.Current.DisplayAlert("Popup Alert", "This is a popup", "Continue", "Cancel");

            Shell.Current.DisplayActionSheet("ActionSheet", "Cancel", "Delete", "Email", "Facebook", "Whatsapp");

            Shell.Current.DisplayPromptAsync("Prompt me", "Whats's your name?", "OK", "Cancel");

        }

        [RelayCommand]
        public async void Notificationn()
        {
            var request = new NotificationRequest
            {
                NotificationId = 100000,
                Title = "New Book",
                Subtitle = "Your new book has arrived",
                Description = "Stay tuned",
                BadgeNumber = 40,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(6),
                    NotifyRepeatInterval = TimeSpan.FromSeconds(20)
                }
            };

            await LocalNotificationCenter.Current.Show(request);
        }

        
    }
}
