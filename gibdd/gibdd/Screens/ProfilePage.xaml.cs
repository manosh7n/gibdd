using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gibdd
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage
    {
        private ProfileData profile { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
        }

        public void setProfile(ProfileData item)
        {
            profile = item;
            InitializationFields();
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
        }

        private async void toIntro(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void deleteProfile(object sender, EventArgs e)
        {
            await App.Database.DeleteProfile(profile);
            await Navigation.PopModalAsync();
        }
        
        private async void saveChanges(object sender, EventArgs e)
        {
            profile.regionAdressed = (string)regionAdressed.SelectedItem;                 
            profile.subdivision = subdivision.Text;                                    
            profile.position = position.Text;                                       
            profile.fioAdressed = fioAdressed.Text;                                    
            profile.fio = fio.Text;                              
            profile.organisation = organisation.IsToggled;                                            
            profile.organisationName = organisationName.Text;                               
            profile.addInfo = addInfo.Text;                                        
            profile.outNumb = outNumb.Text;                                        
            profile.organisationDate = organisationDate.Date.ToString("MM/d/yyyy");         
            profile.letterNumb = letterNumb.Text;                                     
            profile.email = email.Text;                                          
            profile.phone = phone.Text;                                          
            profile.regionIncident = (string)regionIncident.SelectedItem;                 
            profile.alreadyApplied = alreadyApplied.IsToggled;                            
            profile.subdivisionLast = subdivisionLast.Text;                                
            profile.dateAppeal = dateAppeal.Date.ToString("MM/d/yyyy");
            await App.Database.UpdateProfile(profile);
        }
    }
}