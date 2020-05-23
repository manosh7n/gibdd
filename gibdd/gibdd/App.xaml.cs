using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace gibdd
{
    public partial class App : Application
    {
        public static bool isSend = true;
        private const string DATABASE_NAME = "db.db";
        private const string DATABASE_MESS = "messages.db";
        private static ProfileDataDB database;
        private static MessagesDB databaseMessages;
        
        public static ProfileDataDB Database =>
            database ?? (database = new ProfileDataDB(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DATABASE_NAME)));
        
        public static MessagesDB DatabaseMessages =>
            databaseMessages ?? (databaseMessages = new MessagesDB(
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    DATABASE_MESS)));

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new IntroPage());
        }
        
    }
}