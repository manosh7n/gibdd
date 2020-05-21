using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplaintPage : ContentPage
    {
        private ProfileData profile { get; set; }
        public ComplaintPage(ProfileData item)
        {
            profile = item;
            InitializeComponent();
            
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Console.Out.WriteLine(profile.fio);
            Console.Out.WriteLine(profile.regionAdressed);
        }
    }
}