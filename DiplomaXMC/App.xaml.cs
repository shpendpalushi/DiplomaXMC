using DiplomaXMC.Model;
using DiplomaXMC.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient MobileService = new MobileServiceClient("https://diplomaxmc.azurewebsites.net");
        public const string url = "https://localhost:44349/api/Users/GetAllUsers";
        public static string DbLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        static SQLiteHelper db;

        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3"));
                }
                return db;
            }
        }

        public App(string dbLocation)
        {

            InitializeComponent();

            MainPage = new LoginPage();
            DbLocation = dbLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
