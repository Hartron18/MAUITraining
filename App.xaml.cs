using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Interfaces;
using MAUITraining.Models;
using MAUITraining.ViewModels.ProductViewModels;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MAUITraining;

public partial class App : Application
{
	public App()
	{

        InitializeComponent();
        MainPage = new AppShell();
		MainPage.FlowDirection = FlowDirection.LeftToRight;
		
	}

	public static string BaseUrl = "";

    public static View LoadData(Product product, IRelayCommand command)
    {
        if (product == null) { return null; }
        ProductViewModel model = new();
        var pro = model.Products.Where(x => x.Id == product.Id).First();

        Frame frame = new()
        {
            HeightRequest = 80,
            Padding = new Thickness(10),
            IsClippedToBounds = true,
            Content = new Grid
            {
                ColumnDefinitions = Columns.Define(Stars(1), Stars(1), 100),
                Children =
                {
                    new Frame
                    {
                        WidthRequest = 100,
                        Content = new Image { Source = product.ImageUrl}
                        .Aspect(Aspect.AspectFill)
                    }.Column(0).Start().Padding(7),
                    new VerticalStackLayout
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        Children =
                        {
                            new Label{ }.TextColor(Color.FromArgb("#000000"))
                            .Bind(Label.TextProperty, ((ProductViewModel prod) => prod.Products.Where(x => x.Id == product.Id).First().ProductName)),
                            new Label{ Text = product.Price.ToString()}.TextColor(Color.FromArgb("#000000"))
                        }
                    }.Column(1).CenterVertical(),
                    new Button{ Text = "Add to Cart", Command = command, CommandParameter= product.Id, HorizontalOptions = LayoutOptions.End}
                    .Column(2).BackgroundColor(Color.FromArgb("#0000FF")).TextColor(Color.FromArgb("#FFFFFF"))
                    .Height(40).End()

                }

            }

        };

        return frame;

    }
}
