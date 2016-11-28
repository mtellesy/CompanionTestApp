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
            // test 
           
            CScore.BCL.OtherUsers user = new CScore.BCL.OtherUsers();
            user.use_nameEN = text;
           user.use_id = MainActivity.i;
            user.use_nameAR = "TELLESy";
            user.use_phone = 2222;
            user.use_picture = "Tt";
            user.use_typeID = 44;
            user.use_gender = "d";
            user.use_email = "raiden"; 
            user.use_avatar = "raiden";
            user.dep_id = 44;
            user.dep_nameAR = "raiden"; 
            user.dep_nameEN = "raiden";
            user.academicRankAR = "raiden"; 
            user.academicRankEN = "raiden";
            user.academicRankID = 3;

            await UsersD.saveOtherUser(user);
     
         CScore.BCL.OtherUsers user2 = await UsersD.getOtherUser(MainActivity.i++);
         

            if (user2 != null)
                text = user2.use_nameEN;// + "newDB";
            else
                text = "it was null man";
          //  if (user2 == null)
            //    text = "NULL";

            //end of test
     
          //  await UsersD.saveUser(text);

            var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            var adapter = todoListView.Adapter as ArrayAdapter<string>;
         adapter.Add(text);
          
        }
    }
}