using App2.Services;
using App2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;

namespace App2
{
    public partial class App : Application
    {
        private static DB db;
        private static DBUs db_us;

        // Аксессор для получения данных
        public static DB Db
        {
            get
            {
                if (db == null)
                    db = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.diary"));
                return db;
            }
        }
        public static DBUs DbUs
        {
            get
            {
                if (db_us == null)
                    db_us = new DBUs(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.user"));
                return db_us;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
