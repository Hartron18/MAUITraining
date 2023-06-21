
using MAUITraining.CustomControlModel;

namespace MAUITraining.CustomControls;

public class clsMenuView : ContentPage
{
    
    public clsMenuView()
    {
        List<DynaMen> menuDetails = new List<DynaMen>
        {
            new DynaMen{ ImageSource = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg",
            Title = "MenuItem1", Description="My Menu item 1", RouteTo="MenuItem1", MenuCode = "Menu1", SortOrder=10},
            new DynaMen{ ImageSource = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg",
            Title = "MenuItem2", Description="My Menu item 2", RouteTo="MenuItem2", MenuCode = "Menu2", SortOrder=10},
            new DynaMen{ ImageSource = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg",
            Title = "MenuItem3", Description="My Menu item 3", RouteTo="MenuItem3", MenuCode = "Menu3", SortOrder=10},
            new DynaMen{ ImageSource = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885_1280.jpg",
            Title = "MenuItem4", Description="My Menu item 4", RouteTo="MenuItem4", MenuCode = "Menu4", SortOrder=10}
        };

        StackLayout layout = new StackLayout();

        foreach (DynaMen item in menuDetails)
        {
            Image image = new();
            image.Source = item.ImageSource;

            Label Title = new Label { FontSize = 24, TextColor = Color.FromArgb("") };
            Title.Text = item.Title;

            Label Desc = new Label { FontSize = 16, TextColor = Color.FromArgb("") };
            Desc.Text = item.Description;

            VerticalStackLayout TitDesc = new();
            TitDesc.Children.Add(Title);
            TitDesc.Children.Add(Desc);

            ImageButton routeIcon = new ImageButton { Source = ImageSource.FromResource("icon_about.png") };
            //routeIcon.Command = NavigateToCommand;
            //routeIcon.CommandParameter = item.RouteTo;

            Grid grid = new Grid() {};
            grid.Children.Add(image);
            grid.Children.Add(TitDesc);
            grid.Children.Add(grid);
            

            var gridLayout = grid.HorizontalOptions.Alignment;
            gridLayout = LayoutAlignment.Fill;

            //if (item.DetailMenuItem.Count > 0)
            //{
            //	foreach (var itemDetail in item.DetailMenuItem)
            //	{
            //		ContentPage detailPage = new ContentPage();

            //	}
            //}

            layout.Children.Add(grid);
        }

        Content= layout;
        BindingContext = menuDetails;
        Title = "Menu";

    }

}
