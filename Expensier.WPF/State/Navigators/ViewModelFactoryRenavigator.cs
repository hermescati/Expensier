﻿using Expensier.WPF.ViewModels;
using Expensier.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensier.WPF.State.Navigators
{
    public class ViewModelFactoryRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IExpensierViewModelFactory<TViewModel> _viewModelFactory;

        public ViewModelFactoryRenavigator(INavigator navigator, IExpensierViewModelFactory<TViewModel> viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public void Renavigate()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel();
        }
    }
}
