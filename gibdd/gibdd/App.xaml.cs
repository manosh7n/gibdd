using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace gibdd
{
    public partial class App : Application
    {
        private const string DATABASE_NAME = "db.db";
        private static ProfileDataDB database;
        public static ProfileDataDB Database =>
            database ?? (database = new ProfileDataDB(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DATABASE_NAME)));

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IntroPage());
        }

        protected override async void OnStart()
        {
            await App.Database.CreateTable();
        }
        
    }
}