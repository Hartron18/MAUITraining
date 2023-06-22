using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.Input;
using MAUITraining.Interfaces;
using MAUITraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewClasses
{
    public class ListMenuItem : IListItemView
    {
        public View ItemView(object item, IRelayCommand command, bool hasBorder = true)
        {
            if((Type)item == typeof(DynamenItem) && item != null)
            {
                DynamenItem menuItem = (DynamenItem)item;

                Frame frame = new Frame
                {
                    Content = new VerticalStackLayout
                    {
                        Children =
                        {
                            new Frame{ Content = new Image {}.Source(menuItem.ImageSource).Aspect(Aspect.AspectFill)}
                            .Size(30,30).Padding(0),
                            //new Label{}.Text(menuItem.Title).FontSize(12).TextColor(Color.FromArgb("")),
                            new Label{}.Text(menuItem.Description).FontSize(10).TextColor(Color.FromArgb(""))
                        }
                    }
                }.BindTapGesture(nameof(command)).Size(100,100).Padding(5);
                if (hasBorder) 
                    frame.BorderColor = Color.FromArgb(""); 
                return frame;
            }

            return null;
        }
    }
}
