using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Models;

namespace MAUITraining.CustomControls;

public partial class Carousell : StackLayout
{
	public Carousell()
	{
		InitializeComponent();

        List<CarouselDetails> caroDetails = details;

        Carousel.ItemsSource = caroDetails;
        Carousel.CurrentItem = caroDetails.FirstOrDefault(details.Contains);

        Carousel.Dispatcher.StartTimer(new TimeSpan(0, 0, 5), () =>
        {
            Carousel.Dispatcher.DispatchAsync(() =>
            {
                if (Carousel.Position == (details.Count - 1))
                {
                    Carousel.Position = 0;
                
                    return;
                }
                Carousel.Position += 1;

                //if(Carousel.GestureRecognizers.Count > 0) { Carousel.Dispatcher.}
            });
            return true;

        });
        //Carousel.IndicatorView = new IndicatorView
        //{
        //    SelectedIndicatorColor = Color.FromRgba("#3944BC"),
        //    IndicatorColor = Color.FromRgba("#d9f1ff")
        //};
    }

    List<CarouselDetails> details = new List<CarouselDetails>()
    {
        new CarouselDetails{Title = "Image1", Description= "Carousel Image 1", ImageUrl="https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg", NavigateTo="https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg"},
        new CarouselDetails{Title = "Image2", Description= "Carousel Image 2", ImageUrl="https://images.pexels.com/photos/674010/pexels-photo-674010.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500", NavigateTo="https://images.pexels.com/photos/674010/pexels-photo-674010.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"},
        new CarouselDetails{Title = "Image3", Description= "Carousel Image 3", ImageUrl="https://imgd.aeplcdn.com/1056x594/n/cw/ec/44686/activa-6g-right-front-three-quarter.jpeg?q=75", NavigateTo="https://imgd.aeplcdn.com/1056x594/n/cw/ec/44686/activa-6g-right-front-three-quarter.jpeg?q=75"},
        new CarouselDetails{Title = "Image4", Description= "Carousel Image 4", ImageUrl="https://images.unsplash.com/photo-1446750068934-87f7e2f3c3d1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE0fHx8ZW58MHx8fHx8&w=1000&q=80", NavigateTo="https://images.unsplash.com/photo-1446750068934-87f7e2f3c3d1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE0fHx8ZW58MHx8fHx8&w=1000&q=80"},
        new CarouselDetails{Title = "Image5", Description= "Carousel Image 5", ImageUrl="https://images.unsplash.com/photo-1503023345310-bd7c1de61c7d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aHVtYW58ZW58MHx8MHx8fDA%3D&w=1000&q=80", NavigateTo="https://images.unsplash.com/photo-1503023345310-bd7c1de61c7d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aHVtYW58ZW58MHx8MHx8fDA%3D&w=1000&q=80"}
    };

    [RelayCommand]
    public async void ShowDetails()
    {
        await Shell.Current.DisplayAlert(($"{details[Carousel.Position].Title}"),"", "");
    }

    [RelayCommand]
    public async void NavigateTo()
    {
        //await Shell.Current.GoToAsync($"//{details[Carousel.Position].NavigateTo}");
        await Launcher.TryOpenAsync($"{details[Carousel.Position].NavigateTo}");
    }

}