﻿using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.Interfaces
{
    public interface IListItemView
    {
        View ItemView(object item, IRelayCommand command, bool hasBorder = true);
        
    }
}
