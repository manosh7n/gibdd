using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestPage : ContentPage
    {
        public ProfileData profile;
        public string editorText;
        public ObservableCollection<Images> img;

        public RequestPage(
                            ProfileData profile, 
                            string editorText, 
                            ObservableCollection<Images> img)
        {
            this.profile = profile;
            this.editorText = editorText;
            this.img = img;
            BindingContext = this;
            InitializeComponent();
            InitializationFields();
            Title = "Подать обращение";
        }
        
        public void InitializationFields()
        {
            regionAdressed.SelectedItem = profile.regionAdressed;
            subdivision.Text = profile.subdivision;
            position.Text = profile.position;
            fioAdressed.Text = profile.fioAdressed;
            fio.Text = profile.fio;
            organisation.IsToggled = profile.organisation;
            organisationName.Text = profile.organisationName;
            addInfo.Text = profile.addInfo;
            outNumb.Text = profile.outNumb;
            organisationDate.Date = Convert.ToDateTime(profile.organisationDate);
            letterNumb.Text = profile.letterNumb;
            email.Text = profile.email;
            phone.Text = profile.phone;
            regionIncident.SelectedItem = profile.regionIncident;
            alreadyApplied.IsToggled = profile.alreadyApplied;
            subdivisionLast.Text = profile.subdivisionLast;
            dateAppeal.Date = Convert.ToDateTime(profile.dateAppeal);
            editor.Text = editorText;
            imgList.ItemsSource = img;
        }

        private void fullScreenImage(object sender, ItemTappedEventArgs e)
        {
        }
    }
}