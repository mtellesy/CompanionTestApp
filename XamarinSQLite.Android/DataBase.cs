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



namespace XamarinSQLite.Android
{
    [Activity(Label = "XamarinSQLite.Android", Icon = "@drawable/icon")]
    public class Database : Activity
    {

        

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //don't start this activity without pressing login 

            // Set our view from the "database" layout resource
            SetContentView(Resource.Layout.database);
            var addButton = FindViewById<Button>(Resource.Id.AddButton);
            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            addButton.Click += OnAddButtonClicked;
         

            var results = await UsersD.getUsers();
           
            todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, results.ToList());
        }


        private async void OnAddButtonClicked(object sender, EventArgs e)
        {

            var todoEditText = FindViewById<EditText>(Resource.Id.TodoEditText);
            var text = todoEditText.Text;
           todoEditText.Text = string.Empty;
     
            await UsersD.saveUser(text);

            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
            adapter.Add(text);
        }
    }
}