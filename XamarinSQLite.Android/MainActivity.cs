using System;
using System.IO;
using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
using CScore.DataLayer;
using SQLite.Net;
using CScore.DAL;
using CScore.DataLayer.Tables;
using CScore.BCL;


namespace XamarinSQLite.Android
{
    [Activity(Label = "XamarinSQLite.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static int  i = 1 ;
        public static int user_id = 111;
        

        private string GetDbPath()
        {
            string dbname = "SALDBv3.db";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, dbname);
        }
        
        

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            User.use_id = 111;
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var login = FindViewById<Button>(Resource.Id.Login);
            var logout = FindViewById<Button>(Resource.Id.Logout);
            var database = FindViewById<Button>(Resource.Id.Database);
          //  var dae = FindViewById<Button>(Resource.Id.Lt);

            login.Click += OnLoginButtonClicked;
          logout.Click += Logout_Click;
          database.Click += Database_Click;


            

        }

        private void Logout_Click(object sender, EventArgs e)
        {
           
        }

        private void Database_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Database));
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            var path = GetDbPath();
          await DBuilder.InitializeAsync(path, new SQLitePlatformAndroid(), "S");
           // "S" for Student
           
        }

      
    }
}