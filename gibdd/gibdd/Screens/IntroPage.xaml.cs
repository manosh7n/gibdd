using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
            Title = "Выберите профиль";
        }

        private async void createProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProfilePage());
        }
        
        private async void toMainPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}