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
    }
}