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
        public bool isShowStory = false;
        public ImageSource up = ImageSource.FromFile("upChevron.png");
        public ImageSource down = ImageSource.FromFile("downChevron.png");

        public ComplaintPage()
        {
            InitializeComponent();
            BindingContext = this;
            img = new ObservableCollection<Images>();
        }

        protected override async void OnAppearing()
        {
            listMessage.ItemsSource = await App.DatabaseMessages.GetAllMessages();
            base.OnAppearing();
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
            if (!answer) return;
            img.RemoveAt(e.ItemIndex);
            attachCheck();
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
                imgList.IsVisible = false;
                sendButton.IsEnabled = false;
            }
            else
            {
                imgList.IsVisible = true;
                sendButton.IsEnabled = true;
            }
        }

        private void showLastMessages(object sender, EventArgs e)
        {
            if (!isShowStory)
            {
                buttonArrow.Source = up;
                isShowStory = true;
            }
            else
            {
                buttonArrow.Source = down;
                isShowStory = false;
            }
            listMessage.IsVisible = !listMessage.IsVisible;
        }
        
        private void textToEditor(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var temp = (Messages)itemTappedEventArgs.Item;
            editor.Text = temp.message;
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