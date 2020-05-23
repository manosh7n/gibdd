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
            App.isSend = false;
        }
        
        protected override async void OnAppearing()
        {
            await App.Database.CreateTable();
            await App.DatabaseMessages.CreateTable();
            listProfiles.ItemsSource = await App.Database.GetAllProfiles();
            base.OnAppearing();
        }

        private async void createProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateProfilePage());
        }
        
        private async void toMainPage(object sender, EventArgs e)
        { 
            if (App.isSend)
            {
                App.isSend = false;
                mainPage = new MainPage();
            }
            mainPage.setProfile((ProfileData)listProfiles.SelectedItem);
            await Navigation.PushModalAsync(mainPage);
        }
    }
}