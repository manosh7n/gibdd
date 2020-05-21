using Xamarin.Forms;

namespace gibdd
{
    public partial class MainPage : TabbedPage
    {
        private ProfileData profile { get; set; }
        private ComplaintPage tempPageComplaint;
        private ProfilePage tempPageProfile;
        public MainPage()
        {
            InitializeComponent();
            tempPageComplaint= new ComplaintPage() {Title = "Сформировать обращение"};
            tempPageProfile = new ProfilePage() {Title = "Данные профиля"};
            createTabs();
        }

        private void createTabs()
        {
            var pageComplaint = new NavigationPage(tempPageComplaint)
            {
                IconImageSource = "complaint.png", Title = "Обращение"
            };
            var pageProfile = new NavigationPage(tempPageProfile)
            {
                IconImageSource = "account.png", Title = "Профиль"
            };
            
            tempPageProfile.ToolbarItems.Add(new ToolbarItem(
                "Out", "logout.png",async () =>
            {
                await Navigation.PopModalAsync();
            }));

            Children.Add(pageComplaint);
            Children.Add(pageProfile);
        }

        public void setProfile(ProfileData init)
        {
            profile = init;
            tempPageComplaint.setProfile(profile);
            tempPageProfile.setProfile(profile);
        }
    }
}