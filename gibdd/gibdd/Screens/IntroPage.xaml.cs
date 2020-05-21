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
        private MainPage mainPage;
        public IntroPage()
        {
            InitializeComponent();
            Title = "Выберите профиль";
            mainPage = new MainPage();
        }
        
        protected override async void OnAppearing()
        {
            await App.Database.CreateTable();
            listProfiles.ItemsSource = await App.Database.GetAllProfiles();
            base.OnAppearing();
        }

        private async void createProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProfilePage());
        }
        
        private async void toMainPage(object sender, EventArgs e)
        { 
            mainPage.setProfile((ProfileData)listProfiles.SelectedItem);
            await Navigation.PushModalAsync(mainPage);
        }
    }
}