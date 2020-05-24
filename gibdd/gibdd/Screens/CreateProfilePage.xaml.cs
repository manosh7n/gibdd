using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProfilePage : ContentPage
    {
        public bool isValidForm = false;
        public CreateProfilePage()
        {
            InitializeComponent();
            Title = "Создать профиль";
        }

        private async void AddProfile(object sender, EventArgs e)
        {
            if (regionAdressed.SelectedIndex != -1)
            {
                isValidForm = false;
            }

            if (string.IsNullOrWhiteSpace(subdivision.Text) || subdivision.Text.Length < 3)
            {
                isValidForm = false;
                subdivision.TextColor = Color.Brown;
            } 
            else 
            {
                subdivision.TextColor = Color.Black;
            }
            
            if (!Validator.nameValidator(fio.Text))
            {
                isValidForm = false;
                fio.TextColor = Color.Brown;
            } 
            else
            {
                fio.TextColor = Color.Black;
            }
            
            if (!Validator.emailValidator(email.Text))
            {
                isValidForm = false;
                email.TextColor = Color.Brown;
            }
            else
            {
                email.TextColor = Color.Black;
            }

            if (regionAdressed.SelectedIndex != -1 &&
                !string.IsNullOrWhiteSpace(subdivision.Text) && 
                subdivision.Text.Length > 2 &&
                Validator.nameValidator(fio.Text) &&
                Validator.emailValidator(email.Text))
            {
                isValidForm = true;
            }
            
            if (isValidForm)
            {
                var profile = new ProfileData(
                    (string) regionAdressed.SelectedItem,
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
                    (string) regionIncident.SelectedItem,
                    alreadyApplied.IsToggled,
                    subdivisionLast.Text,
                    dateAppeal.Date.ToString("MM/d/yyyy"));
                await App.Database.AddProfile(profile);

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Ошибка", "Неправильно заполненна форма!", "Ок");

            }
        }
        
    }
}