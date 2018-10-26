using DemoApp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DemoApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private bool _isBusy;

        public string Title { get; protected set; }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetValue(ref _isBusy, value);
        }
    }
}
