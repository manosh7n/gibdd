using System;
using System.Collections.ObjectModel;
using gibdd.Screens;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComplaintPage : ContentPage
    {
        private ProfileData profile { get; set; }
        public ObservableCollection<Images> img { get; set; }

        public ComplaintPage()
        {
            InitializeComponent();
            BindingContext = this;
            img = new ObservableCollection<Images>();
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
                    Directory = "deleteLater",
                    Name = $"{DateTime.Now:dd.MM.yyyy_hh.mm.ss}.jpg"
                });

                if (file == null)
                    return;
                
                img.Add(new Images(ImageSource.FromFile(file.Path)));
                imgList.ItemsSource = img;
                attachCheck();
            }
            catch (Exception err)
            {
                await Console.Out.WriteLineAsync(err.Message);
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

                img.Add(new Images(ImageSource.FromFile(file.Path)));
                imgList.ItemsSource = img;
                attachCheck();
            }
            catch (Exception err)
            {
                await Console.Out.WriteLineAsync(err.Message);
            }
        }

        private async void deleteImage(object sender, ItemTappedEventArgs e)
        {
            var answer = await this.DisplayAlert("Удаление", "Удалить фото?", "Да", "Нет");
            if (answer)
            {
                img.RemoveAt(e.ItemIndex);
               attachCheck();
            }
        }

        private async void sendRequest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestPage(profile, editor.Text, img));
        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(editor.Text))
            {
                cameraButton.IsEnabled = false;
                galleryButton.IsEnabled = false;
            }
            else
            {
                cameraButton.IsEnabled = true;
                galleryButton.IsEnabled = true;
            }
        }

        public void attachCheck()
        {
            if (img.Count == 0)
            {
                sendButton.IsEnabled = false;
            }
            else
            {
                sendButton.IsEnabled = true;
            }
        }
    }

    public class Images
    {
        public ImageSource imageSource { get; set; }

        public Images(ImageSource item)
        {
            imageSource = item;
        }

        public Images()
        {
        }
    }
}