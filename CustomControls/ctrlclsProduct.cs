using MAUITraining.CustomControlModel;
using MAUITraining.Models;
using MAUITraining.ViewModels.ProductViewModels;

namespace MAUITraining.CustomControls;

public class ctrlclsProduct : ContentView
{
    VerticalStackLayout stackLayout = new VerticalStackLayout();


    public ctrlclsProduct(ProductViewModel model)
	{
		BindingContext = model;
      
        foreach (Product product in model.Products)
        {
			Frame frame = new()
			{
				HeightRequest = 150,
				IsClippedToBounds = true,
				Content = new HorizontalStackLayout
				{
					Children =
					{
						new Grid
						{
							ColumnDefinitions = { },
							Children =
							{
                                new Image { Source = product.ImageUrl, HeightRequest = 60, WidthRequest= 60},
								new VerticalStackLayout
								{
									Children =
									{
										new Label{ Text = product.ProductName },
										new Label{ Text = product.Price.ToString() }
									}
								},
                                new Button{ Text = "Add to Cart", Command = model.AddtoCartCommand, CommandParameter = product.Id, HorizontalOptions = LayoutOptions.End}
                            }
                            
                        },

					}
				}
			};

			stackLayout.Add(frame);
        }
		Content = stackLayout;

       
	}
	
	
}