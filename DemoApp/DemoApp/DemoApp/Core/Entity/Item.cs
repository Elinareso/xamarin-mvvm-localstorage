using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DemoApp.Core.Entity
{
    public class Item : ObservableObject
    {
        private string _description;
        private string _id;
        private string _text;

        public string Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }
        public string Text
        {
            get => _text;
            set => SetValue(ref _text, value);
        }
        public string Description
        {
            get => _description;
            set => SetValue(ref _description, value);
        }
    }
}
