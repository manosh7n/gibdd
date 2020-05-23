using System;
using Plugin.Media;
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

        private async void takePhoto(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "gibdd",
                    Name = $"{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.jpg"
                });

                if (file == null)
                    return;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
            catch (Exception err)
            {
                Console.Out.WriteLine("Exception error");
            }
        }
        
        private async void pickPhoto(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                    return;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
            catch (Exception err)
            {
                Console.Out.WriteLine("Exception error");
            }
        }
    }
}