using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Text;

namespace MAUITraining.CustomControls;

public partial class FieldEditorCtrl : ContentView
{
	public FieldEditorCtrl()
	{
		InitializeComponent();
	}

    HttpClient _httpClient;

	public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(string), typeof(FieldEditorCtrl));
    public static readonly BindableProperty CaptionProperty = BindableProperty.Create(nameof(Caption), typeof(string), typeof(FieldEditorCtrl));
    public static readonly BindableProperty CapDescriptionProperty = BindableProperty.Create(nameof(CapDescription), typeof(string), typeof(FieldEditorCtrl));
    public static readonly BindableProperty CardImageProperty = BindableProperty.Create(nameof(CardImage), typeof(string), typeof(FieldEditorCtrl));

    [RelayCommand]
	public async void Tap(string? message)
	{
        var prompt = await Shell.Current.DisplayPromptAsync("Fill", message, "Done", "Cancel", "");

        if (prompt != null)
        {
            _httpClient = new();
            string json = JsonConvert.SerializeObject(prompt);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await _httpClient.PutAsync($"{App.BaseUrl}api/", content);

            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                //var snackbar = Snackbar.Make("", action, actionButtonText, duration, snackbarOptions);

                //await snackbar.Show();

                await Shell.Current.DisplaySnackbar("Encountered an error, try again", null,"Dismiss", TimeSpan.FromSeconds(2));
            }
            else 
                await Shell.Current.DisplaySnackbar("Updated Successfully", null, "Dismiss", TimeSpan.FromSeconds(2));

            
        }
        
    }

	public string Caption 
	{ 
		get => GetValue(CaptionProperty) as string;
        set => SetValue(CaptionProperty, value); 
	}

    public string CapDescription
    {
        get => GetValue(CapDescriptionProperty) as string;
        set => SetValue(CapDescriptionProperty, value);
    }

    public string CardImage
    {
        get => GetValue(CardImageProperty) as string;
        set => SetValue(CardImageProperty, value);
    }

    public string Value
    {
        get => GetValue(ValueProperty) as string;
        set => SetValue(ValueProperty, value);
    }
}