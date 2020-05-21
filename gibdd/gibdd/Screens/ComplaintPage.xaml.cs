using System;
using gibdd.Screens;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplaintPage : ContentPage
    {
        private ProfileData profile { get; set; }
        public ComplaintPage()
        {
            InitializeComponent();
        }

        public void setProfile(ProfileData item)
        {
            profile = item;
        }

        private async void sendAppeal(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppealTextPage(profile));
        }
    }
}