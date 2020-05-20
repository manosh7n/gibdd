using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProfilePage : ContentPage
    {
        
        public CreateProfilePage()
        {
            InitializeComponent();
            Title = "Создать профиль";
        }

        private async void AddProfile(object sender, EventArgs e)
        {
            var profile = new ProfileData(
                (string)regionAdressed.SelectedItem,
                subdivision.Text,
                position.Text,
                fioAdressed.Text,
                organisation.IsToggled,
                fio.Text,
                organisationName.Text,
                addInfo.Text, 
                outNumb.Text,
                organisationDate.Date.ToString("MM/d/yyyy"),
                letterNumb.Text,
                email.Text,
                phone.Text,
                (string)regionIncident.SelectedItem,
                alreadyApplied.IsToggled,
                subdivisionLast.Text,
                dateAppeal.Date.ToString("MM/d/yyyy"));
            await App.Database.AddProfile(profile);

            //await App.Database.DropTable();
            await Navigation.PopAsync();
        }
    }
}