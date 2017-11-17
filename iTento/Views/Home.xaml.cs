using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iTento.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.HomeViewModel();
        }
    }
}
