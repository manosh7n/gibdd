using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullScreenPage : ContentPage
    {
        public ImageSource img { get; set; }

        public FullScreenPage(Images item)
        {
            BindingContext = this;
            img = item.imageSource;
            InitializeComponent();
        }

        private async void back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}