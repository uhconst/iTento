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
        }

        void First_Clicked(object sender, System.EventArgs e)
        {
            idFirst.Text = "X";
        }
        void Second_Clicked(object sender, System.EventArgs e)
        {
            idFirst.Text = "X";
        }
    }
}
