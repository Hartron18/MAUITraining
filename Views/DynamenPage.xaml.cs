using MAUITraining.Interfaces;
using MAUITraining.Models;
using MAUITraining.ViewClasses;
using MAUITraining.ViewModels;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MAUITraining.Views;

public partial class DynamenPage : ContentPage
{
    public DynamenViewModel model = new();
    public IListItemView view = new ListMenuItem();
    public DynamenPage()
	{
		InitializeComponent();

        Grid pageLayout = new();
        pageLayout.ColumnDefinitions = Columns.Define();
        ScrollView menusLayout = new();
        StackLayout layout = new();
        foreach (DynamenItem item in model.MenuItems)
        {
            var itemView = view.ItemView(item, model.GotoProductPageCommand);
            layout.Children.Add(itemView);
        }
        menusLayout.Content = layout;
        pageLayout.Children.Add(menusLayout);

        Content = pageLayout;       

    }
}