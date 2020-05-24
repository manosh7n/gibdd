using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullScreenPage : ContentPage
    {
        public Image img { get; set; }
        public FullScreenPage(Images item)
        {
            InitializeComponent();
            BackgroundImageSource = item.imageSource;
        }

        private async void back(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}