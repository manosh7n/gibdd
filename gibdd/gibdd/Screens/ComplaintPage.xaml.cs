using System;
using System.Collections.ObjectModel;
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