using Xamarin.Forms;

namespace gibdd
{
    public partial class MainPage : TabbedPage
    {
        public ProfileData profile { get; set; }
        public MainPage(ProfileData item)
        {
            profile = item;
            
            InitializeComponent();

            var tempPageComplaint = new ComplaintPage(profile) {Title = "Сформировать обращение"};
            var pageComplaint = new NavigationPage(tempPageComplaint)
            {
                IconImageSource = "complaint.png", Title = "Обращение"
            };

            var tempPageProfile = new ProfilePage(profile) {Title = "Данные профиля"};
            tempPageProfile.ToolbarItems.Add(new ToolbarItem("Out", "logout.png",async () =>
            {
                await Navigation.PopModalAsync();
            }));
            var pageProfile = new NavigationPage(tempPageProfile)
            {
                IconImageSource = "account.png", Title = "Профиль"
            };

            Children.Add(pageComplaint);
            Children.Add(pageProfile);
        }
        
    }
}