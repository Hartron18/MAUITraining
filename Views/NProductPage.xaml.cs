using MAUITraining.ViewModels.ProductViewModels;
using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Layouts;
using CommunityToolkit.Maui.Core;
using MAUITraining.Models;
using CommunityToolkit.Mvvm.Input;

namespace MAUITraining.Views;

public partial class NProductPage : ContentPage
{
    public ProductViewModel model;

    public NProductPage()
	{
        
		
		InitializeComponent();
        Shell.Current.ToolbarItems.Clear();

        model = new ();
        Grid pageLayout = new ();
        pageLayout.ColumnDefinitions = Columns.Define();
        ScrollView productsLayout = new ();
        StackLayout layout = new();
        layout.Spacing = 10;
        layout.Padding = new Thickness(10);

        foreach (var item in model.Products)
        {
            var productView = App.LoadData(item, model.AddtoCartCommand);
           
            layout.Children.Add(productView); 
        }

        productsLayout.Content = layout;
        Button payButton = new()
        {
            Text = "Click to Pay",
            BackgroundColor = Color.FromArgb("#CD7F32"),
            TranslationX = 100,
            TranslationY = 300

        };
        pageLayout.Children.Add(productsLayout.Column(0));
        pageLayout.Children.Add(payButton.Column(0).Size(100, 50).TextColor(Color.FromArgb("#FFFFFF")));

        BindingContext = model;
        Content = pageLayout;
	}


    //private static View LoadData(Product product, IRelayCommand command)
    //{
    //    if (product == null) { return null; }
    //    ProductViewModel model = new();
    //    var pro = model.Products.Where(x => x.Id == product.Id).First(); 

    //    Frame frame = new()
    //    {
    //        HeightRequest = 80,
    //        Padding = new Thickness(10),
    //        IsClippedToBounds = true,
    //        Content = new Grid
    //        {
    //            ColumnDefinitions = Columns.Define(Stars(1), Stars(1), 100),
    //            Children =
    //            {
    //                new Frame
    //                {
    //                    WidthRequest = 100,
    //                    Content = new Image { Source = product.ImageUrl}
    //                    .Aspect(Aspect.AspectFill)
    //                }.Column(0).Start().Padding(7),
    //                new VerticalStackLayout
    //                {
    //                    HorizontalOptions = LayoutOptions.Start,
    //                    Children =
    //                    {
    //                        new Label{ }.TextColor(Color.FromArgb("#000000"))
    //                        .Bind(Label.TextProperty, ((ProductViewModel prod) => prod.Products.Where(x => x.Id == product.Id).First().ProductName)),
    //                        new Label{ Text = product.Price.ToString()}.TextColor(Color.FromArgb("#000000"))
    //                    }
    //                }.Column(1).CenterVertical(),
    //                new Button{ Text = "Add to Cart", Command = command, CommandParameter= product.Id, HorizontalOptions = LayoutOptions.End}
    //                .Column(2).BackgroundColor(Color.FromArgb("#0000FF")).TextColor(Color.FromArgb("#FFFFFF"))
    //                .Height(40).End()

    //            }

    //        }

    //    };

    //    return frame;

    //}
}