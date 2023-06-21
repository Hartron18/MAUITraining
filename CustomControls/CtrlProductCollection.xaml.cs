using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MAUITraining.CustomControls;

public partial class CtrlProductCollection : ContentView
{
    
    public static readonly BindableProperty CollectionSourceProperty = BindableProperty.Create(nameof(CollectionSource), typeof(List<object>), typeof(CtrlProductCollection));
    public static readonly BindableProperty ProductNameProperty = BindableProperty.Create(nameof(ProductName), typeof(string), typeof(CtrlProductCollection));
	public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(CtrlProductCollection));
    public static readonly BindableProperty PriceProperty = BindableProperty.Create(nameof(Price), typeof(decimal), typeof(CtrlProductCollection));
    public static readonly BindableProperty CartQuantityProperty = BindableProperty.Create(nameof(CartQuantity), typeof(int?), typeof(CtrlProductCollection));
    public static readonly BindableProperty CommandEventProperty = BindableProperty.Create(nameof(CommandEvent), typeof(RelayCommand), typeof(CtrlProductCollection));
    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CtrlProductCollection));

    
    public CtrlProductCollection()
	{
		InitializeComponent();
        
        

    }

    public List<object> CollectionSource
    {
        get => GetValue(CollectionSourceProperty) as List<object>;
        set => SetValue(CollectionSourceProperty, value);
    }

    public string ImageUrl
    {
        get => GetValue(ImageUrlProperty) as string;
        set => SetValue(ImageUrlProperty, value);
    }

    public string ProductName
    {
        get => GetValue(ProductNameProperty) as string;
        set => SetValue(ProductNameProperty, value);
    }

    public decimal? Price
    {
        get => GetValue(PriceProperty) as decimal?;
        set => SetValue(PriceProperty, value);
    }

    public int? CartQuantity
    {
        get => GetValue(CartQuantityProperty) as int?;
        set => SetValue(CartQuantityProperty, value);
    }

    public RelayCommand CommandEvent
    {
        get => GetValue(CommandEventProperty) as RelayCommand;
        set => SetValue(CommandEventProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandEventProperty) as object;
        set => SetValue(CommandEventProperty, value);
    }
}